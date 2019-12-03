namespace MusicHub.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using AutoMapper;
    using Data;
    using MusicHub.Data.Models;
    using MusicHub.Data.Models.Enums;
    using MusicHub.DataProcessor.ImportDtos;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data";

        private const string SuccessfullyImportedWriter
            = "Imported {0}";
        private const string SuccessfullyImportedProducerWithPhone
            = "Imported {0} with phone: {1} produces {2} albums";
        private const string SuccessfullyImportedProducerWithNoPhone
            = "Imported {0} with no phone number produces {1} albums";
        private const string SuccessfullyImportedSong
            = "Imported {0} ({1} genre) with duration {2}";
        private const string SuccessfullyImportedPerformer
            = "Imported {0} ({1} songs)";

        public static string ImportWriters(MusicHubDbContext context, string jsonString)
        {
            var writers = JsonConvert.DeserializeObject<Writer[]>
                (jsonString);

            var sb = new StringBuilder();
            var writersToImport = new List<Writer>();
            foreach (var writer in writers)
            {
                if (!IsValid(writer))
                {
                    sb.AppendLine("Invalid data");
                    continue;
                }
                else
                {
                    sb.AppendLine(string.Format(SuccessfullyImportedWriter, writer.Name));
                    writersToImport.Add(writer);
                }
            }

            context.Writers.AddRange(writersToImport);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportProducersAlbums(MusicHubDbContext context, string jsonString)
        {
            var producersAlbums = JsonConvert.DeserializeObject<ImportProducerDto[]>
                (jsonString);

            var producers = new List<Producer>();
            var albums = new List<Album>();
            var sb = new StringBuilder();
            foreach (var producerAlbum in producersAlbums)
            {
                bool areAlbumsValid = producerAlbum.Albums.All(x => IsValid(x));
                if (!IsValid(producerAlbum) || !areAlbumsValid)
                {
                    sb.AppendLine("Invalid data");
                }
                else
                {
                    var producer = new Producer
                    {
                        Name = producerAlbum.Name,
                        PhoneNumber = producerAlbum.PhoneNumber,
                        Pseudonym = producerAlbum.Pseudonym,
                    };

                    foreach (var album in producerAlbum.Albums)
                    {
                        var albumToList = Mapper.Map<Album>(album);
                        albums.Add(albumToList);
                        producer.Albums.Add(albumToList);
                    }

                    producers.Add(producer);
                    if (producer.PhoneNumber != null)
                    {
                        sb.AppendLine(string.Format(SuccessfullyImportedProducerWithPhone, producer.Name,
                                                                                        producer.PhoneNumber,
                                                                                        producer.Albums.Count));
                    }
                    else
                    {
                        sb.AppendLine(string.Format(SuccessfullyImportedProducerWithNoPhone, producer.Name,
                                                                                        producer.Albums.Count));
                    }

                }
            }

            context.Producers.AddRange(producers);
            context.Albums.AddRange(albums);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportSongs(MusicHubDbContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(ImportSongDto[]),
                new XmlRootAttribute("Songs"));

            ImportSongDto[] songDtos;
            using (var reader = new StringReader(xmlString))
            {
                songDtos = (ImportSongDto[])
                    serializer.Deserialize(reader);
            }

            var sb = new StringBuilder();
            var songs = new List<Song>();
            foreach (var songDto in songDtos)
            {
                var isValidGenre = Enum.IsDefined(typeof(Genre), songDto.Genre);
                var isValidWriter = context.Writers.Any(x => x.Id == songDto.WriterId);
                var isValidAlbum = context.Albums.Any(x => x.Id == songDto.AlbumId);
                if (!IsValid(songDto) || 
                    !isValidGenre ||
                    !isValidWriter ||
                    !isValidAlbum)
                {
                    sb.AppendLine(ErrorMessage);
                }
                else
                {
                    var song = Mapper.Map<Song>(songDto);
                    sb.AppendLine(string.Format(SuccessfullyImportedSong, song.Name, song.Genre, song.Duration));
                    songs.Add(song);
                }
            }

            context.Songs.AddRange(songs);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportSongPerformers(MusicHubDbContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(ImportPerformerDto[]),
                new XmlRootAttribute("Performers"));

            var performers = new List<Performer>();
            ImportPerformerDto[] performerDtos;
            using (var reader = new StringReader(xmlString))
            {
                performerDtos = (ImportPerformerDto[])
                    serializer.Deserialize(reader);
            }

            var sb = new StringBuilder();
            foreach (var performerDto in performerDtos)
            {
                var songsAreValid = performerDto.PerformerSongs.All(s => context.Songs.Any(z => z.Id == s.SongId));
                if (!songsAreValid || 
                    !IsValid(performerDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                else
                {
                    var performer = new Performer()
                    {
                        FirstName = performerDto.FirstName,
                        LastName = performerDto.LastName,
                        Age = performerDto.Age,
                        NetWorth = performerDto.NetWorth
                    };

                    foreach (var song in performerDto.PerformerSongs.Select(x => x.SongId))
                    {
                        var songPerformer = new SongPerformer
                        {
                            Performer = performer,
                            SongId = song
                        };

                        performer.PerformerSongs.Add(songPerformer);
                        performers.Add(performer);
                    }

                    sb.AppendLine(string.Format(SuccessfullyImportedPerformer, performer.FirstName,
                                                                                performer.PerformerSongs.Count));
                }
            }

            context.Performers.AddRange(performers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(obj, validationContext, results, true);

            return isValid;
        }
    }
}
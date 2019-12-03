namespace MusicHub.DataProcessor
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using MusicHub.DataProcessor.ExportDtos;
    using Newtonsoft.Json;

    public class Serializer
    {
        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var albums = context.Albums
                .Where(a => a.ProducerId == producerId)
                .Select(a => new
                {
                    AlbumName = a.Name,
                    ReleaseDate = a.ReleaseDate.ToString("MM/dd/yyyy"),
                    ProducerName = a.Producer.Name,
                    Songs = a.Songs
                             .Select(s => new
                             {
                                 SongName = s.Name,
                                 Price = $"{s.Price:f2}",
                                 Writer = s.Writer.Name
                             })
                             .OrderByDescending(s => s.SongName)
                             .ThenBy(s => s.Writer),
                    AlbumPrice = $"{a.Songs.Sum(s => s.Price):f2}"
                })
                .OrderByDescending(a => decimal.Parse(a.AlbumPrice));

            var serializer = JsonConvert.SerializeObject(albums, Formatting.Indented);

            return serializer.ToString().Trim();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var songs = context.Songs
                .Where(s => s.Duration.TotalSeconds > duration)
                .Select(s => new ExportSongDto
                {
                    SongName = s.Name,
                    Writer = s.Writer.Name,
                    Performer = s.SongPerformers.FirstOrDefault().Performer.FirstName + " " + s.SongPerformers.FirstOrDefault().Performer.LastName,
                    AlbumProducer = s.Album.Producer.Name,
                    Duration = s.Duration.ToString("c")
                })
                .OrderBy(s => s.SongName)
                .ThenBy(s => s.Writer)
                .ThenBy(s => s.Performer)
                .ToArray();

            var serializer = new XmlSerializer(typeof(ExportSongDto[]),
                new XmlRootAttribute("Songs"));
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            var sb = new StringBuilder();
            using (var writer = new StringWriter(sb))
            {
                serializer.Serialize(writer, songs, namespaces);
            }

            return sb.ToString().TrimEnd();
        }
    }
}
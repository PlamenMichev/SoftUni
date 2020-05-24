using IRunes.Models;
using IRunes.Services.Interfaces;
using IRunes.ViewModels.Tracks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRunes.Services
{
    public class TracksService : ITracksService
    {
        private readonly ApplicationDbContext db;

        public TracksService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void CreateTrack(string name, string link, decimal price, string albumId)
        {
            Track track = new Track()
            {
                Name = name,
                Price = price,
                Link = link,
                AlbumId = albumId
            };

            this.db.Tracks.Add(track);
            var album = this.db
                .Albums
                .FirstOrDefault(x => x.Id == albumId);

            decimal currentPrice = album
                .Tracks
                .Sum(x => x.Price);
            album.Price = currentPrice * 0.87m;

            this.db.SaveChanges();
        }

        public TrackDetailsViewModel GetDetailsViewModel(string albumId, string trackId)
        {
            TrackDetailsViewModel result = this.db
                .Tracks
                .Where(x => x.Id == trackId)
                .Select(x => new TrackDetailsViewModel
                {
                    Name = x.Name,
                    Price = x.Price,
                    AlbumId = x.AlbumId,
                    Link = x.Link
                })
                .FirstOrDefault();

            return result;
        }
    }
}

using IRunes.Models;
using IRunes.Services.Interfaces;
using IRunes.ViewModels.Albums;
using IRunes.ViewModels.Tracks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRunes.Services
{
    public class AlbumsService : IAlbumsService
    {
        private readonly ApplicationDbContext db;

        public AlbumsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void CreateAlbum(string name, string cover)
        {
            Album album = new Album()
            {
                Name = name,
                Cover = cover,
                Price = 0.0m,
            };

            this.db.Albums.Add(album);
            this.db.SaveChanges();
        }

        public AllViewModel GetAllViewModel()
        {
            AllViewModel result = new AllViewModel
            {
                Albums = this.db
                .Albums
                .Select(x => new AlbumViewModel
                {
                    Name = x.Name,
                    Id = x.Id
                })
            };

            return result;
        }

        public DetailsViewModel GetDetailsViewModel(string id)
        {
            var albumViewModel = this.db
                .Albums
                .Where(x => x.Id == id)
                .Select(x => new DetailsViewModel
                {
                    Name = x.Name,
                    Id = x.Id,
                    Price = x.Price,
                    Cover = x.Cover,
                    Tracks = x.Tracks
                    .Select(t => new TrackListViewModel
                    {
                        Id = t.Id,
                        Name = t.Name
                    })
                })
                .FirstOrDefault();

            return albumViewModel;
        }
    }
}

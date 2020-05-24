using IRunes.Services.Interfaces;
using IRunes.ViewModels.Tracks;
using SIS.HTTP;
using SIS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace IRunes.Controllers
{
    public class TracksController : Controller
    {
        private readonly ITracksService tracksService;

        public TracksController(ITracksService tracksService)
        {
            this.tracksService = tracksService;
        }

        public HttpResponse Create(string albumId)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            CreateViewModel model = new CreateViewModel
            {
                AlbumId = albumId
            };

            return this.View(model);
        }

        [HttpPost]
        public HttpResponse Create(CreateTrackInputModel model)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (model.Name.Length < 4 || model.Name.Length > 20)
            {
                return this.Error("Track name must be between 4 and 20 characters!");
            }

            if (model.Price < 0)
            {
                return this.Error("Price must be non-negative number!");
            }

            if (string.IsNullOrWhiteSpace(model.Link))
            {
                return this.Error("Invalid link!");
            }

            this.tracksService.CreateTrack(model.Name, model.Link, model.Price, model.AlbumId);
            return this.Redirect("/Albums/Details?id=" + model.AlbumId);
        }

        public HttpResponse Details(string albumId, string trackId)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }
            TrackDetailsViewModel model = this.tracksService.GetDetailsViewModel(albumId, trackId);

            if (model == null)
            {
                return this.Error("Track Not Found!");
            }

            return this.View(model);
        }


    }
}

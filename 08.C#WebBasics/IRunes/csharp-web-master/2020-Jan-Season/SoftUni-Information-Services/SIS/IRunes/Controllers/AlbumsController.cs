using IRunes.Services.Interfaces;
using IRunes.ViewModels.Albums;
using SIS.HTTP;
using SIS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace IRunes.Controllers
{
    public class AlbumsController : Controller
    {
        private readonly IAlbumsService albumsService;

        public AlbumsController(IAlbumsService albumsService)
        {
            this.albumsService = albumsService;
        }

        public HttpResponse Create()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse Create(CreateInputModel model)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (model.Name.Length < 4 || model.Name.Length > 20)
            {
                return this.View("Album name must be between 4 and 20 characters!");
            }

            if (string.IsNullOrWhiteSpace(model.Cover))
            {
                return this.View("Invalid Cover");
            }

            this.albumsService.CreateAlbum(model.Name, model.Cover);
            return this.Redirect("/Albums/All");
        }

        public HttpResponse All()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            AllViewModel model = this.albumsService.GetAllViewModel();

            return this.View(model);
        }

        public HttpResponse Details(string id)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            DetailsViewModel model = this.albumsService.GetDetailsViewModel(id);

            if (model == null)
            {
                return this.Error("Album Not Found!");
            }

            return this.View(model);
        }
    }
}

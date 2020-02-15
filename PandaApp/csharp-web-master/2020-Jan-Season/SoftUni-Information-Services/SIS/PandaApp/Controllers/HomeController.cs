using PandaApp.Services.Interfaces;
using PandaApp.ViewModels.User;
using SIS.HTTP;
using SIS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace PandaApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUsersService usersService;

        public HomeController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        [HttpGet("/")]
        public HttpResponse Index()
        {
            if (this.User != null)
            {
                var model = new HomeViewModel
                {
                    Username = this.usersService.GetUserUsername(this.User),
                };

                return this.View(model, "IndexLoggedIn");
            }


            return this.View();
        }
    }
}


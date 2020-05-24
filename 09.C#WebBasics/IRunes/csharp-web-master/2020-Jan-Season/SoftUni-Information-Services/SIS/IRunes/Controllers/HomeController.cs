using IRunes.Services.Interfaces;
using IRunes.ViewModels.Users;
using SIS.HTTP;
using SIS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace IRunes.Controllers
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
                IndexViewModel model = new IndexViewModel()
                {
                    Username = this.usersService.GetUsername(this.User),
                };

                return this.View(model, "Home");
            }

            return this.View();
        }

        [HttpGet("/Home/Index")]
        public HttpResponse IndexFullPath()
        {
            return this.Redirect("/");
        }
    }
}

using PandaApp.Services.Interfaces;
using PandaApp.ViewModels.Packages;
using SIS.HTTP;
using SIS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace PandaApp.Controllers
{
    public class PackagesController : Controller
    {
        private readonly IUsersService usersService;
        private readonly IPackagesService packagesService;

        public PackagesController(IUsersService usersService, IPackagesService packagesService)
        {
            this.usersService = usersService;
            this.packagesService = packagesService;
        }

        public HttpResponse Create()
        {
            string[] model = this.usersService.GetAllUsersUsernames();
            return this.View(model);
        }

        [HttpPost]
        public HttpResponse Create(CreatePackageInputModel model)
        {
            //Add validations
            this.packagesService.CreatePackage(model);

            return this.Redirect(@"\Packages\Pending");
        }

        public HttpResponse Pending()
        {
            PendingPackagesInputModel model = this.packagesService.GetPendingPackages();
            
            return this.View(model);
        }

        public HttpResponse Deliver(string id)
        {
            this.packagesService.DeliverPackage(id);

            return this.Redirect(@"\Packages\Delivered");
        }

        public HttpResponse Delivered(string id)
        {
            PendingPackagesInputModel model = this.packagesService.GetDeliveredPackages();

            return this.View(model);
        }
    }
}

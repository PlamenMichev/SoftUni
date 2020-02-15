using PandaApp.Models;
using PandaApp.Models.Enums;
using PandaApp.Services.Interfaces;
using PandaApp.ViewModels.Packages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PandaApp.Services
{
    public class PackagesService : IPackagesService
    {
        private readonly ApplicationDbContext db;
        private readonly IUsersService usersService;

        public PackagesService(ApplicationDbContext db, IUsersService usersService)
        {
            this.db = db;
            this.usersService = usersService;
        }

        public void CreatePackage(CreatePackageInputModel model)
        {
            string userId = this.usersService.GetIdWithUsername(model.RecipientName);

            var package = new Package
            {
                Id = Guid.NewGuid().ToString(),
                ShippingAddress = model.ShippingAddress,
                Description = model.Description,
                Status = Status.Pending,
                Weight = model.Weight,
                RecipientId = userId,
            };

            this.db.Packages.Add(package);
            this.db.SaveChanges();
        }

        public void DeliverPackage(string id)
        {
            var package = this.db.Packages
                .First(x => x.Id == id);

            package.Status = Status.Delivered;
            var receipt = new Receipt
            {
                Id = Guid.NewGuid().ToString(),
                Fee = Convert.ToDecimal(package.Weight * 2.67),
                IssuedOn = DateTime.UtcNow,
                RecipientId = package.RecipientId,
                PackageId = package.Id
            };

            this.db.Add(receipt);
            this.db.SaveChanges();
        }

        public PendingPackagesInputModel GetDeliveredPackages()
        {
            PendingPackagesInputModel result = new PendingPackagesInputModel();

            var packages = this.db.Packages.Where(x => x.Status == Status.Delivered).ToArray();

            foreach (var package in packages)
            {
                var user = this.usersService.GetUserObject(package.RecipientId);
                var modelPackage = new SinglePackageViewModel
                {
                    Id = package.Id,
                    Description = package.Description,
                    ShippingAddress = package.ShippingAddress,
                    RecipientName = user.Username,
                    Weight = package.Weight,
                };
                result.Packages.Add(modelPackage);
            }


            return result;
        }

        public PendingPackagesInputModel GetPendingPackages()
        {
            PendingPackagesInputModel result = new PendingPackagesInputModel();

            var packages = this.db.Packages.Where(x => x.Status == Status.Pending).ToArray();

            foreach (var package in packages)
            {
                var user = this.usersService.GetUserObject(package.RecipientId);
                var modelPackage = new SinglePackageViewModel
                {
                    Id = package.Id,
                    Description = package.Description,
                    ShippingAddress = package.ShippingAddress,
                    RecipientName = user.Username,
                    Weight = package.Weight,
                };
                result.Packages.Add(modelPackage);
            }


            return result;
        }
    }
}

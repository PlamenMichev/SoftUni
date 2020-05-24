using PandaApp.ViewModels.Packages;
using System;
using System.Collections.Generic;
using System.Text;

namespace PandaApp.Services.Interfaces
{
    public interface IPackagesService
    {
        void CreatePackage(CreatePackageInputModel model);

        PendingPackagesInputModel GetPendingPackages();

        void DeliverPackage(string id);

        PendingPackagesInputModel GetDeliveredPackages();
    }
}

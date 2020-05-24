using IRunes.ViewModels.Albums;
using System;
using System.Collections.Generic;
using System.Text;

namespace IRunes.Services.Interfaces
{
    public interface IAlbumsService
    {
        void CreateAlbum(string name, string cover);

        AllViewModel GetAllViewModel();

        DetailsViewModel GetDetailsViewModel(string id);
    }
}

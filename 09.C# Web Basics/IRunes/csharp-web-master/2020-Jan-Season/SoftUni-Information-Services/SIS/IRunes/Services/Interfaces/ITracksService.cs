using IRunes.ViewModels.Tracks;
using System;
using System.Collections.Generic;
using System.Text;

namespace IRunes.Services.Interfaces
{
    public interface ITracksService
    {
        void CreateTrack(string name, string link, decimal price, string albumId);

        TrackDetailsViewModel GetDetailsViewModel(string albumId, string trackId);
    }
}

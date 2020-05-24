using IRunes.ViewModels.Tracks;
using System;
using System.Collections.Generic;
using System.Text;

namespace IRunes.ViewModels.Albums
{
    public class DetailsViewModel
    {
        public string Name { get; set; }

        public string Id { get; set; }

        public decimal Price { get; set; }

        public string Cover { get; set; }

        public IEnumerable<TrackListViewModel> Tracks { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace PandaApp.ViewModels
{
    public class ListRecieptsViewModel
    {
        public string Id { get; set; }

        public DateTime IssuedOn { get; set; }

        public decimal Fee { get; set; }

        public string RecipientName { get; set; }
    }
}

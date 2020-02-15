using SIS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace PandaApp.Models
{
    public class User : IdentityUser<string>
    {
        public ICollection<Package> Packages { get; set; } = new HashSet<Package>();

        public ICollection<Receipt> Receipts { get; set; } = new HashSet<Receipt>();
    }
}

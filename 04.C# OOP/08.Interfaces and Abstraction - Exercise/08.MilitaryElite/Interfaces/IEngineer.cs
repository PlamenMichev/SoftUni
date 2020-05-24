using _08.MilitaryElite.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace _08.MilitaryElite.Interfaces
{
    public interface IEngineer
    {
        HashSet<Repair> Repairs { get; set; }
    }
}

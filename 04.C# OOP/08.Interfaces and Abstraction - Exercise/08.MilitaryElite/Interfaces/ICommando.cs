using _08.MilitaryElite.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace _08.MilitaryElite.Interfaces
{
    public interface ICommando
    {
        HashSet<Mission> Missions { get; set; }
    }
}

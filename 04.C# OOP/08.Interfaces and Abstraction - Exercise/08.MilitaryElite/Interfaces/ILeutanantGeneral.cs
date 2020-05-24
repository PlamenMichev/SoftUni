using System;
using System.Collections.Generic;
using System.Text;

namespace _08.MilitaryElite
{
    public interface ILieutanantGeneral
    {
        HashSet<Private> Privates { get; set; }
    }
}

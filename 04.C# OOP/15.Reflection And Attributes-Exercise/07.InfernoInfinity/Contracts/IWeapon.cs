using _07.InfernoInfinity.Enums;
using _07.InfernoInfinity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace _07.InfernoInfinity.Contracts
{
    public interface IWeapon
    {
        string Name { get; }

        Stats Stats { get; }
        
        LevelOfRearity LevelOfRearity { get; }

        List<Gem> Gems { get; }

        string CalculateDamage();
    }
}

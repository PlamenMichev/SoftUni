using _07.InfernoInfinity.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace _07.InfernoInfinity.Models.Weapons
{
    public class Axe : Weapon
    {
        public Axe(string name, Stats stats, LevelOfRearity levelOfRearity, List<Gem> gems) 
            : base(name, stats, levelOfRearity, gems)
        {
            this.Stats.MinDamage = 5 * (int)LevelOfRearity;
            this.Stats.MaxDamage = 10 * (int)LevelOfRearity;
            this.Stats.NumberOfSockets = 4 * (int)LevelOfRearity;
        }

        
    }
}

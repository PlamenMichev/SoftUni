using _07.InfernoInfinity.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace _07.InfernoInfinity.Models.Weapons
{
    public class Knife : Weapon
    {
        public Knife(string name, Stats stats, LevelOfRearity levelOfRearity, List<Gem> gems) 
            : base(name, stats, levelOfRearity, gems)
        {
            this.Stats.MinDamage = 3 * (int)LevelOfRearity;
            this.Stats.MaxDamage = 4 * (int)LevelOfRearity;
            this.Stats.NumberOfSockets = 2 * (int)LevelOfRearity;
        }
    }
}

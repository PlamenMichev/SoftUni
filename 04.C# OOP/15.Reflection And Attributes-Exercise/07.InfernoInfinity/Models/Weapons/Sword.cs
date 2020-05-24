using _07.InfernoInfinity.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace _07.InfernoInfinity.Models.Weapons
{
    public class Sword : Weapon
    {
        public Sword(string name, Stats stats, LevelOfRearity levelOfRearity, List<Gem> gems) 
            : base(name, stats, levelOfRearity, gems)
        {
            this.Stats.MinDamage = 4 * (int)LevelOfRearity;
            this.Stats.MaxDamage = 6 * (int)LevelOfRearity;
            this.Stats.NumberOfSockets = 3 * (int)LevelOfRearity;
        }
    }
}

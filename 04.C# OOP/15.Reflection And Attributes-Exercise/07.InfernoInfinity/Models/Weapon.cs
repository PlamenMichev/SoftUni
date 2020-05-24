using _07.InfernoInfinity.Contracts;
using _07.InfernoInfinity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _07.InfernoInfinity.Models
{
    public abstract class Weapon : IWeapon
    {
        protected Weapon(string name, Stats stats, LevelOfRearity levelOfRearity, List<Gem> gems)
        {
            this.Name = name;
            this.Stats = stats;
            this.LevelOfRearity = levelOfRearity;
            this.Gems = gems;
            this.GemPlacement = new Dictionary<int, Gem>();
        }

        public Dictionary<int, Gem> GemPlacement { get; set; }

        public string Name { get; set; }

        public Stats Stats { get; set; }

        public LevelOfRearity LevelOfRearity { get; set; }

        public List<Gem> Gems { get; set; }

        public virtual string CalculateDamage()
        {
            foreach (var gem in GemPlacement)
            {
                this.Stats.MinDamage += GemPlacement.Values.Select(x => x.Strength * 2).Sum() ;
                this.Stats.MaxDamage += GemPlacement.Values.Select(x => x.Strength * 3).Sum() ;
                this.Stats.MinDamage += GemPlacement.Values.Select(x => x.Agility * 1).Sum() ;
                this.Stats.MaxDamage += GemPlacement.Values.Select(x => x.Agility * 4).Sum() ;
            }

            return $"{this.Stats.MinDamage}-{this.Stats.MaxDamage}";
        }

        public override string ToString()
        {
            return $"{this.Name}: {this.CalculateDamage()} Damage, " +
                $"+{this.GemPlacement.Select(x => x.Value.Strength).Sum()} Strength, " +
                $"+{this.GemPlacement.Select(x => x.Value.Agility).Sum()} Agility, " +
                $"+{this.GemPlacement.Select(x => x.Value.Vitality).Sum()} Vitality";
        }
    }
}

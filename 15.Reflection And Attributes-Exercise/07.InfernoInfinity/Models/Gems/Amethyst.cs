using _07.InfernoInfinity.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace _07.InfernoInfinity.Models.Gems
{
    public class Amethyst : Gem
    {
        public Amethyst(GemsQuality quality) 
            : base(quality)
        {
            this.Strength = 2 + (int)this.Quality;
            this.Agility = 8 + (int)this.Quality;
            this.Vitality = 4 + (int)this.Quality;
        }
    }
}

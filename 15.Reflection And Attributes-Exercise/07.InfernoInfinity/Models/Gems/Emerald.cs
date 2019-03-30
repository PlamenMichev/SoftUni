using _07.InfernoInfinity.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace _07.InfernoInfinity.Models.Gems
{
    public class Emerald : Gem
    {
        public Emerald(GemsQuality quality)
        : base(quality)
        {
            this.Strength = 1 + (int)this.Quality;
            this.Agility = 4 + (int)this.Quality;
            this.Vitality = 9 + (int)this.Quality;
        }

    }
}

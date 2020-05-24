using _07.InfernoInfinity.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace _07.InfernoInfinity.Models.Gems
{
    public class Ruby : Gem
    {
        public Ruby(GemsQuality quality) 
            : base(quality)
        {
            this.Strength = 7 + (int)this.Quality;
            this.Agility = 2 + (int)this.Quality;
            this.Vitality = 5 + (int)this.Quality;
        }
    }
}

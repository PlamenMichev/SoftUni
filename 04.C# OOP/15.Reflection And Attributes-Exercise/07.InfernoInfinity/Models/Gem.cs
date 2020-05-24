using _07.InfernoInfinity.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace _07.InfernoInfinity.Models
{
    public class Gem
    {
        public Gem(GemsQuality quality)
        {
            this.Quality = quality;
        }

        public GemsQuality Quality { get; set; }

        public int Strength { get; set; }

        public int Agility { get; set; }

        public int Vitality { get; set; }
    }
}

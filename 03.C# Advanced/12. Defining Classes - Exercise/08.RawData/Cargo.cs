﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _08.RawData
{
    public class Cargo
    {
        public int CargoWeight { get; set; }

        public string CargoType { get; set; }

        public Cargo(int weight, string type)
        {
            this.CargoWeight = weight;
            this.CargoType = type;
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniRestaurant.Models.Drinks
{
    public class Water : Drink
    {
        private const decimal currentPrice = 1.50M;

        public Water(string name, int servingSize,string brand) 
            : base(name, servingSize, currentPrice, brand)
        {
        }
    }
}

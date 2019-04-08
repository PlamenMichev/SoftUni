using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniRestaurant.Models.Drinks
{
    public class Alcohol : Drink
    {
        private const decimal currentPrice = 3.50M;

        public Alcohol(string name, int servingSize, string brand) 
            : base(name, servingSize, currentPrice, brand)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniRestaurant.Models.Drinks
{
    public class FuzzyDrink : Drink
    {
        private const decimal currentPrice = 2.50M;

        public FuzzyDrink(string name, int servingSize, string brand) 
            : base(name, servingSize, currentPrice, brand)
        {
        }
    }
}

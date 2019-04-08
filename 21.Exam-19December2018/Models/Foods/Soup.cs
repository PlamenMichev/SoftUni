using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniRestaurant.Models.Foods
{
    public class Soup : Food
    {
        private const int currentServingSize = 245;

        public Soup(string name, decimal price) 
            : base(name, currentServingSize, price)
        {
        }
    }
}

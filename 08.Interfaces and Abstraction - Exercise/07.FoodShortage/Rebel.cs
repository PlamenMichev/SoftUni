using System;
using System.Collections.Generic;
using System.Text;

namespace _07.FoodShortage
{
    public class Rebel : Existable
    {
        public Rebel(string name, int age, string group) 
            : base(name, age, group)
        {
            base.Food = 0;
        }

        public override int BuyFood()
        {
            base.Food += 5;

            return 5;
        }
    }
}

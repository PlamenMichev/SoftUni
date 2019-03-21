using System;
using System.Collections.Generic;
using System.Text;

namespace _07.FoodShortage
{
    public class Citizen : Existable
    {
        public Citizen(string name, int age, string id, DateTime birthDate) 
            : base (name, age, id, birthDate)
        {
            base.Food = 0;
        }

        public override int BuyFood()
        {
            base.Food += 10;

            return 10;
        }
    }
}

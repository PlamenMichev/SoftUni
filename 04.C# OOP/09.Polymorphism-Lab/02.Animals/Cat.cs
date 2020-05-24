using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Cat : Animal
    {
        public Cat(string name, string favouriteFood) 
            : base(name, favouriteFood)
        {
        }

        public override string ExplainSelf()
        {
            return $"I am {base.Name} and my fovourite food is {base.FavouriteFood} MEEOW";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace _03.WildFarm.Models.Animal_Hierarchy.Mammals.Felines
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, int foodEaten) 
            : base(name, weight, foodEaten)
        {
        }

        public Tiger(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        public override string ProduceSound()
        {
            return "ROAR!!!";
        }

        public override void Eat(string food, int weightToEat)
        {
            Validator.ValidateMeat(food, "Tiger");

            this.Weight += weightToEat * 1.00;
            base.Eat(food, weightToEat);
        }
    }
}

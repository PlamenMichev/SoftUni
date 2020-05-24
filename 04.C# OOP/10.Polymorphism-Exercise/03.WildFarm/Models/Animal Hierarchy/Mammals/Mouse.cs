using System;
using System.Collections.Generic;
using System.Text;

namespace _03.WildFarm.Models.Animal_Hierarchy.Mammals
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, int foodEaten) 
            : base(name, weight, foodEaten)
        {
        }

        public Mouse(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        public override string ProduceSound()
        {
            return "Squeak";
        }

        public override void Eat(string food, int weightToEat)
        {
            try
            {
                Validator.ValidateVegetables(food, "Mouse");
            }
            catch (Exception ex)
            {
                try
                {
                    Validator.ValidateFruit(food, "Mouse");
                }
                catch (Exception newEx)
                {
                    throw newEx;
                }
            }

            this.Weight += weightToEat * 0.10;
            base.Eat(food, weightToEat);
        }
    }
}

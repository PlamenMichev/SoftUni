using System;
using System.Collections.Generic;
using System.Text;

namespace _03.WildFarm.Models.Animal_Hierarchy.Mammals.Felines
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, int foodEaten) 
            : base(name, weight, foodEaten)
        {
        }

        public Cat(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        public override string ProduceSound()
        {
            return "Meow";
        }

        public override void Eat(string food, int weightToEat)
        {
            try
            {
                Validator.ValidateVegetables(food, "Cat");
            }
            catch (Exception ex)
            {
                try
                {
                    Validator.ValidateMeat(food, "Cat");
                }
                catch (Exception newEx)
                {
                    throw newEx;
                }
            }
            
            
        
            this.Weight += weightToEat * 0.30;
            base.Eat(food, weightToEat);
        }
    }
}

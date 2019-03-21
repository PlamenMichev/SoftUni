using System;
using System.Collections.Generic;
using System.Text;

namespace _03.WildFarm.Models.Animal_Hierarchy.Mammals
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, int foodEaten) 
            : base(name, weight, foodEaten)
        {
        }

        public Dog(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        public override string ProduceSound()
        {
            return "Woof!";
        }

        public override void Eat(string food, int weightToEat)
        {
            Validator.ValidateMeat(food, "Dog");

            this.Weight += weightToEat * 0.40;
            base.Eat(food, weightToEat);
        }
    }
}

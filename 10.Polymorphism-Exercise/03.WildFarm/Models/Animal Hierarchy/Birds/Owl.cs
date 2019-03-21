using System;
using System.Collections.Generic;
using System.Text;

namespace _03.WildFarm.Models.Animal_Hierarchy.Birds
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, int foodEaten) 
            : base(name, weight, foodEaten)
        {
        }

        public Owl(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }

        public override void Eat(string food, int weightToEat)
        {
            Validator.ValidateMeat(food, "Owl");

            this.Weight += weightToEat * 0.25;
            base.Eat(food, weightToEat);
        }
    }
}

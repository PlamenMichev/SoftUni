using System;
using System.Collections.Generic;
using System.Text;

namespace _03.WildFarm.Models.Animal_Hierarchy.Birds
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, int foodEaten) 
            : base(name, weight, foodEaten)
        {
        }

        public Hen(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        public override string ProduceSound()
        {
            return "Cluck";
        }

        public override void Eat(string food, int weightToEat)
        {
            this.Weight += weightToEat * 0.35;
            base.Eat(food, weightToEat);
        }
    }
}

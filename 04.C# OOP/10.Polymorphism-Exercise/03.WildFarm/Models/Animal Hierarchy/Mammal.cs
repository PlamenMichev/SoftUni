using System;
using System.Collections.Generic;
using System.Text;

namespace _03.WildFarm.Models.Animal_Hierarchy
{
    public class Mammal : Animal
    {
        public Mammal(string name, double weight, int foodEaten) 
            : base(name, weight, foodEaten)
        {
        }

        public Mammal(string name, double weight, string livingRegion)
            : base(name, weight)
        {
            this.LivingRegion = livingRegion;
        }

        public string LivingRegion { get; private set; }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}

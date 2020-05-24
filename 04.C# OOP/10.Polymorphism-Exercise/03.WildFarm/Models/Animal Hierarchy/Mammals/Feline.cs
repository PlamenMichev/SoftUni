using System;
using System.Collections.Generic;
using System.Text;

namespace _03.WildFarm.Models.Animal_Hierarchy.Mammals
{
    public abstract class Feline : Mammal
    {
        public Feline(string name, double weight, int foodEaten) 
            : base(name, weight, foodEaten)
        {
        }

        public Feline(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion)
        {
            this.Breed = breed;
        }

        public string Breed { get; private set; }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Breed}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}

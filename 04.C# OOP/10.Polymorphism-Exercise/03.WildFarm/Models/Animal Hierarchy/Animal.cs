using System;
using System.Collections.Generic;
using System.Text;

namespace _03.WildFarm.Models.Animal_Hierarchy
{
    public abstract class Animal
    {
        protected Animal(string name, double weight, int foodEaten)
        {
            this.Name = name;
            this.Weight = weight;
            this.FoodEaten = foodEaten;
        }

        protected Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }

        public string Name { get; protected set; }

        public double Weight { get; protected set; }

        public int FoodEaten { get; protected set; }

        public virtual string ProduceSound()
        {
            return "";
        }

        public virtual void Eat(string food, int weightToEat)
        {
            this.FoodEaten += weightToEat;
        }
    }
}

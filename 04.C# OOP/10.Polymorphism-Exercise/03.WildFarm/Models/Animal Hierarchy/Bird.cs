using System;
using System.Collections.Generic;
using System.Text;

namespace _03.WildFarm.Models.Animal_Hierarchy
{
    public abstract class Bird : Animal
    {
        protected Bird(string name, double weight, int foodEaten) 
            : base(name, weight, foodEaten)
        {
        }

        protected Bird(string name, double weight, double wingSize)
            : base(name, weight)
        {
            this.WingSize = wingSize;
        }

        public double WingSize { get; private set; }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {WingSize}, {this.Weight}, {this.FoodEaten}]";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public abstract class Animal
    {
        private string name;
        private string favouriteFood;

        protected Animal(string name, string favouriteFood)
        {
            this.Name = name;
            this.FavouriteFood = favouriteFood;
        }

        protected string Name { get => this.name; set => this.name = value; }
        protected string FavouriteFood { get => this.favouriteFood; set => this.favouriteFood = value; }

        public abstract string ExplainSelf();
    }
}

using _03.WildFarm.Food_Hierarchy;
using System;
using System.Collections.Generic;
using System.Text;

namespace _03.WildFarm.Factories
{
    public class FoodFactory
    {
        public Food Create(string name, int weight)
        {
            switch (name)
            {
                case nameof(Vegetable):
                    {
                        return new Vegetable(weight);
                    }
                case nameof(Fruit):
                    {
                        return new Fruit(weight);
                    }
                case nameof(Meat):
                    {
                        return new Meat(weight);
                    }
                case nameof(Seeds):
                    {
                        return new Seeds(weight);
                    }
                default:
                    {
                        return null;
                    }
            }
        }
    }
}

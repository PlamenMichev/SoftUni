using _03.WildFarm.Food_Hierarchy;
using System;
using System.Collections.Generic;
using System.Text;

namespace _03.WildFarm
{
    public static class Validator
    {
        public static void ValidateVegetables(string food, string animalType)
        {
            if (food != nameof(Vegetable))
            {
                throw new ArgumentException($"{animalType} does not eat {food}!");
            }
        }

        public static void ValidateFruit(string food, string animalType)
        {
            if (food != nameof(Fruit))
            {
                throw new ArgumentException($"{animalType} does not eat {food}!");
            }
        }

        public static void ValidateMeat(string food, string animalType)
        {
            if (food != nameof(Meat))
            {
                throw new ArgumentException($"{animalType} does not eat {food}!");
            }
        }
    }
}

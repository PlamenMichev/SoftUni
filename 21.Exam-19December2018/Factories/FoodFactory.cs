using SoftUniRestaurant.Models.Foods.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SoftUniRestaurant.Factories
{
    public class FoodFactory
    {
        public IFood Create(string type, string name, decimal price)
        {
            Type typeOfFood = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name == type);

            var constructors = typeOfFood.GetConstructors();
            var constructor = constructors[0];

            var objectToInstance = (IFood)Activator.CreateInstance(typeOfFood, new object[] { name, price });

            return objectToInstance;
        }
    }
}

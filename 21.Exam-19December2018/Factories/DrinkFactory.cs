using SoftUniRestaurant.Models.Drinks.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SoftUniRestaurant.Factories
{
    public class DrinkFactory
    {
        public IDrink Create(string type, string name, int servingSize, string brand)
        {
            Type typeOfFood = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name == type);

            var constructors = typeOfFood.GetConstructors();
            var constructor = constructors[0];
            var objectToInstance = (IDrink)Activator.CreateInstance(typeOfFood, new object[] { name, servingSize, brand });

            return objectToInstance;
        }
    }
}

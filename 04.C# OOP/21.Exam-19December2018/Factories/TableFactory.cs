using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using SoftUniRestaurant.Models.Tables.Contracts;

namespace SoftUniRestaurant.Factories
{
    public class TableFactory
    {
        public ITable Create(string type, int tableNumber, int capacity)
        {
            Type typeOfFood = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name.ToLower() == type.ToLower() + "table");

            var constructors = typeOfFood.GetConstructors();
            var constructor = constructors[0];
            var objectToInstance = (ITable)Activator.CreateInstance(typeOfFood, new object[] { tableNumber, capacity });

            return objectToInstance;
        }
    }
}

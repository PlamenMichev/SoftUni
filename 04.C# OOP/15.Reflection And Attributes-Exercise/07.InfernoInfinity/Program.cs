using _07.InfernoInfinity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace _07.InfernoInfinity
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Weapon> weapons = new List<Weapon>();
            string input = Console.ReadLine();
            while (input != "END")
            {
                string[] tokens = input
                    .Split(";");
                string weaponName = tokens[1];

                string command = tokens[0];
                Type commandType = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name == command);
                var commandInstance = Activator.CreateInstance(commandType);
                MethodInfo executeMethod = commandType.GetMethod("Execute");

                executeMethod.Invoke(commandInstance, new object[] { weapons, tokens });


                input = Console.ReadLine();
            }
        }
    }
}

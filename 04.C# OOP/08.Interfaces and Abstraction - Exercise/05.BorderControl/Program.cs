using System;
using System.Collections.Generic;

namespace _05.BorderControl
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IIdable> citizens = new List<IIdable>();

            string input = Console.ReadLine();
            while(input != "End")
            {
                string[] tokens = input
                    .Split();
                
                
                if (tokens.Length == 3)
                {
                    string name = tokens[0];
                    string id = tokens[2];
                    int age = int.Parse(tokens[1]);
                    var person = new Person(name, id, age);
                    citizens.Add(person);
                }
                else
                {
                    string model = tokens[0];
                    string id = tokens[1];
                    var robbot = new Robot(id, model);
                    citizens.Add(robbot);
                }

                input = Console.ReadLine();
            }

            string line = Console.ReadLine();

            foreach (var citizen in citizens)
            {
                if (citizen.EndsWith(line))
                {
                    Console.WriteLine(citizen.Id);
                }
            }
        }
    }
}

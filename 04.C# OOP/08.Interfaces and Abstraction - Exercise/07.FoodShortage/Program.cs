using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace _07.FoodShortage
{
    public class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            List<Existable> citizens = new List<Existable>();

            for (int i = 0; i < count; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split();

                string name = tokens[0];
                int age = int.Parse(tokens[1]);
                if (tokens.Length == 4)
                {
                    string id = tokens[2];
                    DateTime birthDate = DateTime.ParseExact(tokens[3], "dd/MM/yyyy", CultureInfo.InvariantCulture);

                    var citizen = new Citizen(name, age, id, birthDate);
                    citizens.Add(citizen);
                }
                else
                {
                    string group = tokens[2];

                    var rebel = new Rebel(name, age, group);
                    citizens.Add(rebel);
                }
            }

            string input = Console.ReadLine();
            int sum = 0;
            while(input != "End")
            {
                var citizen = citizens.FirstOrDefault(x => x.Name == input);
                if (citizen != null)
                {
                    sum += citizen.BuyFood();
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(sum);
        }
    }
}

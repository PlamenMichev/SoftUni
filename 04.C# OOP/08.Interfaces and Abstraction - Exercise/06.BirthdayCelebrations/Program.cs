using System;
using System.Collections.Generic;
using System.Globalization;

namespace _06.BirthdayCelebrations
{
    class Program
    {
        public static object CulturelInfo { get; private set; }

        static void Main(string[] args)
        {
            List<IBornable> citizens = new List<IBornable>();

            string input = Console.ReadLine();
            while(input != "End")
            {
                string[] tokens = input
                    .Split();
                string type = tokens[0];
                
                if (type == "Citizen")
                {
                    string name = tokens[1];
                    string id = tokens[3];
                    int age = int.Parse(tokens[2]);
                    DateTime birthday = DateTime.ParseExact(tokens[4], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    var person = new Person(name, id, age, birthday);
                    citizens.Add(person);
                }
                else if (type == "Pet")
                {
                    string name = tokens[1];
                    DateTime birthday = DateTime.ParseExact(tokens[2], "dd/MM/yyyy", CultureInfo.InvariantCulture);

                    var pet = new Pet(name, birthday);
                    citizens.Add(pet);
                }

                input = Console.ReadLine();
            }
            try
            {
                string date = Console.ReadLine();

                foreach (var citizen in citizens)
                {
                    string dateToCompare = citizen.BirthDate.Year.ToString();
                    if (dateToCompare == date)
                    {
                        Console.WriteLine(citizen.BirthDate.ToString("dd/MM/yyyy"));
                    }
                }
            }
            catch (Exception ex)
            {
                ex = new ArgumentException("<empty output>");
                Console.WriteLine(ex.Message);
            }


        }
    }
}

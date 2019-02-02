using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace Problem_5._Filter_by_Age
{
    public class Person
    {
        public string Name { get; set; }

        public int Age { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            var people = new List<Person>();
            for (int i = 0; i < length; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);

                string name = input[0];
                int age = int.Parse(input[1]);
                var person = new Person
                {
                    Name = name,
                    Age = age
                        
                };
                people.Add(person);
            }

            string command = Console.ReadLine();
            int ageToFilter = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();



            Func<Person, bool> filterPredicate;
            if (command == "older")
            {
                filterPredicate = p => p.Age >= ageToFilter;
            }
            else
            {
                filterPredicate = p => p.Age < ageToFilter;
            }

            Func<Person, string> selectFunc;
            if (format == "name age")
            {
                selectFunc = p => $"{p.Name} - {p.Age}";
            }
            else
            {
                if (format == "name")
                {
                    selectFunc = p => $"{p.Name}";
                }
                else
                {
                    selectFunc = p => $"{p.Age}";
                }
            }
            people
                .Where(filterPredicate)
                .Select(selectFunc)
                .ToList()
                .ForEach(Console.WriteLine);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            List<Person> people = new List<Person>();

            for (int i = 0; i < length; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = input[0];
                int age = int.Parse(input[1]);
                var currentPerson = new Person();
                currentPerson.Name = name;
                currentPerson.Age = age;
                people.Add(currentPerson);
            }

            foreach (var person in people.Where(x => x.Age > 30).OrderByDescending(x => x.Name))
            {
                Console.WriteLine($"{person.Name} {person.Age}");
            }
        }
    }
}

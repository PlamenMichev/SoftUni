using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonsInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            int length = int.Parse(Console.ReadLine());
            for (int i = 0; i < length; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string firstName = tokens[0];
                string lastName = tokens[1];
                int age = int.Parse(tokens[2]);
                var currentPerson = new Person(firstName, lastName, age);
                people.Add(currentPerson);
            }

            foreach (var person in people.OrderBy(x => x.FirstName).ThenBy(x => x.Age))
            {
                Console.WriteLine($"{person}");
            }
        }
    }
}

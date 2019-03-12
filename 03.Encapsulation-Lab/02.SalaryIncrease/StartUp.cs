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
                decimal salary = decimal.Parse(tokens[3]);
                var currentPerson = new Person(firstName, lastName, age, salary);
                people.Add(currentPerson);
            }

            var parcentage = decimal.Parse(Console.ReadLine());
            people.ForEach(p => p.IncreaseSalary(parcentage));
            people.ForEach(p => Console.WriteLine(p.ToString()));

        }
    }
}

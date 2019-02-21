using System;
using System.Collections.Generic;
using DefiningClasses;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            var family = new Family();
            for (int i = 0; i < length; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = input[0];
                int age = int.Parse(input[1]);

                var currentPerson = new Person(name, age);
                family.AddMember(currentPerson);
            }
           
            var oldestMember = family.GetOldestMember();
            Console.WriteLine($"{oldestMember.Name} {oldestMember.Age}");
        }
    }
}

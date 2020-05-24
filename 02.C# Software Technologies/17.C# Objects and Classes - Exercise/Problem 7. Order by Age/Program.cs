using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_7._Order_by_Age
{
    class Person
    {
        public Person(string name, string id, int age)
        {
            this.Name = name;
            this.ID = id;
            this.Age = age;
        }
        public string Name { get; set; }
        public string ID { get; set; }
        public int Age { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            while (true)
            {
                string[] input = Console.ReadLine()
                    .Split()
                    .ToArray();
                if (input[0] == "End")
                {
                    break;
                }
                Person currentPerson = new Person(input[0], input[1], int.Parse(input[2]));
                people.Add(currentPerson);
            }

            foreach (var person in people.OrderBy(x=>x.Age))
            {
                Console.WriteLine($"{person.Name} with ID: {person.ID} is {person.Age} years old.");
            }
        }
    }
}

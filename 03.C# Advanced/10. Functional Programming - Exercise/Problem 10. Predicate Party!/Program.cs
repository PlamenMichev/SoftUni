using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Reflection.Metadata;

namespace Problem_10._Predicate_Party_
{
    class Program
    {
        static void Main(string[] args)
        {

            var names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Party!")
                {
                    break;
                }

                string[] tokens = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = tokens[0];
                string filterCommand = tokens[1];
                string criteria = tokens[2];
                Func<string, string, bool> predicate;
                predicate = GetFunc(filterCommand);
                if (command == "Remove")
                {
                   names = names
                        .Where(x => !predicate(x, criteria))
                        .ToList();
                }
                if (command == "Double")
                {
                    List<string> namesToDouble = new List<string>();

                    namesToDouble = names
                        .Where(x => predicate(x, criteria))
                        .ToList();


                    foreach (var name in namesToDouble)
                    {
                        int index = names.IndexOf(name);
                        names.Insert(index + 1, name);
                    }
                }

            }
            if (names.Count != 0)
            {
                Console.WriteLine($"{string.Join(", ", names)} are going to the party!");
            }
            else
            {
                Console.WriteLine($"Nobody is going to the party!");
            }

        }

        static Func<string, string, bool> GetFunc(string filterCommand)
        {
            if (filterCommand == "StartsWith")
            {
                return (x, c) => x.StartsWith(c);
            }
            if (filterCommand == "EndsWith")
            {
                return (x, c) => x.EndsWith(c);
            }
            if (filterCommand == "Length")
            {
                return (x, c) => x.Length == int.Parse(c);
            }

            return null;
        }
    }
}

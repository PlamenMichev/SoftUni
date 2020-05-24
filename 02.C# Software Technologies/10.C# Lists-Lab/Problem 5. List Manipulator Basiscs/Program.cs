using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_5._List_Manipulator_Basiscs
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            while (true)
            {
                string input = Console.ReadLine();
                if(input == "end")
                {
                    break;
                }
                string[] tokens = input.Split();
                string command = tokens[0];
                int num = int.Parse(tokens[1]);
                switch (command)
                {
                    case "Add":
                        numbers.Add(num);
                        break;
                    case "Remove":
                        numbers.Remove(num);
                        break;
                    case "RemoveAt":
                        numbers.RemoveAt(num);
                        break;
                    case "Insert":
                        numbers.Insert(int.Parse(tokens[2]), num);
                        break;

                }

            }
                Console.WriteLine(string.Join(" ", numbers));
        }
    }
}

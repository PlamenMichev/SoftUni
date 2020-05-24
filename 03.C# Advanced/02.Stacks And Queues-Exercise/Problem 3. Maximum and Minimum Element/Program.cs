using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_3._Maximum_and_Minimum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> numbers = new Stack<int>();
            int length = int.Parse(Console.ReadLine());
            for (int i = 0; i < length; i++)
            {
                int[] tokens = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
                int command = tokens[0];
                if (command == 1)
                {
                    int num = tokens[1];
                    numbers.Push(num);
                }

                if (command == 2 && numbers.Any() == true)
                {
                    numbers.Pop();
                }

                if (command == 3 && numbers.Any() == true)
                {
                    Console.WriteLine(numbers.Max());
                }

                if (command == 4 && numbers.Any() == true)
                {
                    Console.WriteLine(numbers.Min());
                }
            }

            List<int> result = new List<int>();
            int stackLength = numbers.Count;
            for (int i = 0; i < stackLength; i++)
            {

                result.Add(numbers.Pop());
            }

            Console.WriteLine(string.Join(", ", result));
        }
    }
}

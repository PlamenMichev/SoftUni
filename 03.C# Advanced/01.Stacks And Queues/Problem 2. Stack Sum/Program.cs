using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_2._Stack_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            Stack<int> stackWithNumbers = new Stack<int>(numbers);
            while (true)
            {
                string input = Console.ReadLine();
                input = input.ToLower();
                if (input == "end")
                {
                    break;
                }

                string[] tokens = input.Split();
                if (tokens[0] == "add")
                {
                    int firstNum = int.Parse(tokens[1]);
                    int secNum = int.Parse(tokens[2]);
                    stackWithNumbers.Push(firstNum);
                    stackWithNumbers.Push(secNum);
                }
                else if (tokens[0] == "remove")
                {
                    int numbersToRemove = int.Parse(tokens[1]);
                    if (numbersToRemove > stackWithNumbers.Count)
                    {
                        continue;
                    }
                    else
                    {
                        for (int i = 0; i < numbersToRemove; i++)
                        {
                            stackWithNumbers.Pop();
                        }
                    }
                }
            }

            Console.WriteLine($"Sum: {stackWithNumbers.Sum()}");
        }
    }
}

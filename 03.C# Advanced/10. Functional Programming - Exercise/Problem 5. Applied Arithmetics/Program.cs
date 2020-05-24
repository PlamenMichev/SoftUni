using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_5._Applied_Arithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<List<int>, List<int>> add = x => x.Select(n => n + 1).ToList();
            Func<List<int>, List<int>> multiply = x => x.Select(n => n * 2).ToList();
            Func<List<int>, List<int>> subtract = x => x.Select(n => n - 1).ToList();
            Action<List<int>> print = x => Console.WriteLine(string.Join(" ", x));
            var numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end")
                {
                    break;
                }
                if (input == "add")
                {
                    numbers = add(numbers);
                }
                if (input == "subtract")
                {
                    numbers = subtract(numbers);
                }
                if (input == "multiply")
                {
                    numbers = multiply(numbers);
                }
                if (input == "print")
                {
                    print(numbers);
                }
            }
        }

    }
}

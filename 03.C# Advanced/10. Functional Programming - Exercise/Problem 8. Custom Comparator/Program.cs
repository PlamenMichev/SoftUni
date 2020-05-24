using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_8._Custom_Comparator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            var evenNums = numbers
                .Where(x => x % 2 == 0)
                .ToList();
            var oddNums = numbers
                .Where(x => x % 2 != 0)
                .ToList();
            evenNums.Sort();
            oddNums.Sort();
            Console.WriteLine(string.Join(" ", evenNums) + " " + string.Join(" ", oddNums));
        }
    }
}

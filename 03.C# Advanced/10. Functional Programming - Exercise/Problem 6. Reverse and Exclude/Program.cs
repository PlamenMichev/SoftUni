using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_6._Reverse_and_Exclude
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<List<int>> reverse = x => x.Reverse();
            
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            reverse(numbers);
            int numToDivide = int.Parse(Console.ReadLine());
            Func<int, int, bool> isDivisible = (x, num) => x % num == 0;
            var result = new List<int>();
            numbers
                .Where(x => isDivisible(x, numToDivide) == false)
                .ToList()
                .ForEach(x => Console.Write($"{x} "));
            Console.WriteLine();
        }
    }
}

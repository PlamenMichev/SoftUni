using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_7._Predicate_for_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            Func<int, int, bool> compareLength = (x, y) => x <= y;
             Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Where(n => compareLength(n.Length, length))
                .ToList()
                .ForEach(x => Console.WriteLine(x));
        }
    }
}

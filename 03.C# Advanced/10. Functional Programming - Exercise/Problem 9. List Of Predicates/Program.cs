using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_9._List_Of_Predicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            Func<int, List<int>, bool> isDivisableByAll = isDevisibleByAll;
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            List<int> result = new List<int>();
            for (int i = 1; i <= length; i++)
            {
                if (isDivisableByAll(i, numbers))
                {
                    result.Add(i);
                }
            }

            Console.WriteLine(string.Join(" ", result));
        }

        public static bool isDevisibleByAll(int num, List<int> nums)
        {
            foreach (var number in nums)
            {
                if (num % number != 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}

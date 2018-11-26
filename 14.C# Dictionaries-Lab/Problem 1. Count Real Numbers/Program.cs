using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_1._Count_Real_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new List<double>();
            numbers = Console.ReadLine()
                .Split(' ')
                .Select(double.Parse)
                .ToList();
            var counts = new SortedDictionary<double, int>();
            for (int i = 0; i < numbers.Count; i++)
            {
                if (counts.ContainsKey(numbers[i]))
                {
                    counts[numbers[i]]++;
                }
                else
                {
                    counts.Add(numbers[i], 1);
                }
            }

            foreach (var kvp in counts)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");

            }
        }
    }
}

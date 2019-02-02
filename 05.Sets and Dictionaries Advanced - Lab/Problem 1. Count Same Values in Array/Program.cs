using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_1._Count_Same_Values_in_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<double, int> dict = new Dictionary<double, int>();
            double[] numbers = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToArray();
            foreach (var number in numbers)
            {
                if (!dict.ContainsKey(number))
                {
                    dict[number] = 0;
                }

                dict[number]++;
            }

            foreach (var kvp in dict)
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value} times");
            }
        }
    }
}

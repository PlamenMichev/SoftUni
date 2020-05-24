using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_5._Count_Symbols
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var letters = new Dictionary<char, int>();
            foreach (var letter in input)
            {
                if (!letters.ContainsKey(letter))
                {
                    letters[letter] = 0;
                }

                letters[letter]++;
            }
            foreach (var kvp in letters.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value} time/s");
            }
        }
    }
}

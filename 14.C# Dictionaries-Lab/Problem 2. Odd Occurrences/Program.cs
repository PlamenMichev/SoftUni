using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_2._Odd_Occurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine()
                .Split();
            Dictionary<string, int> count = new Dictionary<string, int>();
            foreach (var word in words)
            {
                string wordInLower = word.ToLower();
                if (count.ContainsKey(wordInLower))
                {
                    count[wordInLower]++;
                }
                else count.Add(wordInLower, 1);
            }

            foreach (var item in count)
            {
                if(item.Value % 2 != 0)
                {
                    Console.Write(item.Key + " ");
                }
            }
        }

    }
}

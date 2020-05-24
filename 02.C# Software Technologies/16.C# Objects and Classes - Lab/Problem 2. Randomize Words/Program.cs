using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_2._Randomize_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            var words = new List<string>();
            words = Console.ReadLine()
                .Split()
                .ToList();
            int length = words.Count;
            for (int i = 0; i < length; i++)
            {
                int randomIndex = random.Next(0, length);
                string temp = words[i];
                words[i] = words[randomIndex];
                words[randomIndex] = temp;
            }

            for (int i = 0; i < length; i++)
            {
                Console.WriteLine(words[i]);
            }
        }
    }
}

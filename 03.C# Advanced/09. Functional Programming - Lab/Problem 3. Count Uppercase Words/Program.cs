using System;
using System.Linq;

namespace Problem_3._Count_Uppercase_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, bool> isUpper = word => char.IsUpper(word[0]);
            string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Where(isUpper)
                .ToArray();
            foreach (var word in input)
            {
                Console.WriteLine(word);
            }
        }
    }
}

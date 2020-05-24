using System;
using System.Linq;

namespace Problem_4._Text_Filter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] bannedWords = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            string input = Console.ReadLine();
            for (int i = 0; i < bannedWords.Length; i++)
            {
                string wordToBan = bannedWords[i];
                input = input.Replace(wordToBan, new string('*', wordToBan.Length));
            }

            Console.WriteLine(input);
        }
    }
}

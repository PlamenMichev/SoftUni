using System;
using System.Linq;

namespace Problem_2._Repeat_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine()
                .Split()
                .ToArray();
            string answer = "";
            for (int i = 0; i < words.Length; i++)
            {
                string word = words[i];
                for (int j = 0; j < word.Length; j++)
                {
                    answer += word;
                }
            }

            Console.WriteLine(answer);
        }
    }
}

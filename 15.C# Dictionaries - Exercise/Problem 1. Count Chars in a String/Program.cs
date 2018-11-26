using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_1._Count_Chars_in_a_String
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            char[] stringToChar = input.ToCharArray();
            var numOfChars = new Dictionary<char, int>();
            foreach (var letter in stringToChar)
            {
                if (letter != ' ')
                {
                    if (!numOfChars.ContainsKey(letter))
                    {
                        numOfChars[letter] = 0;
                    }

                    numOfChars[letter]++;
                }

            }

            foreach (var kvp in numOfChars)
            {
                Console.WriteLine(kvp.Key + " -> " + kvp.Value);
            }
        }
    }
}

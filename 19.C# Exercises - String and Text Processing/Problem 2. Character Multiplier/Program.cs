using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices.WindowsRuntime;

namespace Problem_2._Character_Multiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputs = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string firstString = inputs[0];
            string secString = inputs[1];
            Console.WriteLine(Sum(firstString, secString));
        }

        static int Sum(string firstString, string secString)
        {
            if (secString.Length > firstString.Length)
            {
                string x = secString;
                secString = firstString;
                firstString = x;
            }
            int sum = 0;
            for (int i = 0; i < secString.Length; i++)
            {
                sum += firstString[i] * secString[i];
            }

            if (secString.Length != firstString.Length)
            {
                int length = firstString.Length - secString.Length;
                for (int i = firstString.Length - length; i < firstString.Length; i++)
                {
                    sum += firstString[i];
                }
            }
            return sum;
        }

    }
}

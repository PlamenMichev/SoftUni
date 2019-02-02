using System;
using System.Collections.Generic;

namespace Problem_4.Matching_Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<int> symbols = new Stack<int>();
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                     symbols.Push(i);
                }
                else if (input[i] == ')')
                {
                    int lastIndexBracket = symbols.Pop();
                    Console.WriteLine(input.Substring(lastIndexBracket, i - lastIndexBracket + 1));
                }
            }
        }
    }
}

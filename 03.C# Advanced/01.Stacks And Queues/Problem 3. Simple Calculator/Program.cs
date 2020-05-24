using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Problem_3._Simple_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string[] input = Console.ReadLine().Split();
            Stack<string> symbols = new Stack<string>(input.Reverse());

            int result = int.Parse(symbols.Pop());
            while (symbols.Any())
            {
                string nextSymbol = symbols.Pop();
                if (nextSymbol == "+")
                {
                    result += int.Parse(symbols.Pop());
                }
                else if(nextSymbol == "-")
                {
                    result -= int.Parse(symbols.Pop());
                }
            }

            Console.WriteLine(result);
        }
    }
}

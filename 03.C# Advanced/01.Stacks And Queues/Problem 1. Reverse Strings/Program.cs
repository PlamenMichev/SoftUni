using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_1._Reverse_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<char> stack = new Stack<char>();
            string input = Console.ReadLine();
            foreach (var temp in input)
            {
                stack.Push(temp);
            }

            int length = stack.Count;
            for (int i = 0; i < length; i++)
            {
                if (length - 1 == i)
                {
                    Console.WriteLine(stack.Pop());
                }
                else Console.Write(stack.Pop());                
            }
        }
    }
}

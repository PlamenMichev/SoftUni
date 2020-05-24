using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Problem_8._Balanced_Parentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine().Trim();

            if (input.Length % 2 != 0)
            {
                Console.WriteLine("NO");
                return;
            }
            
            Stack<char> sequence = new Stack<char>(input);
            int length = sequence.Count;
            for (int i = 0; i < length; i++)
            {
                if (input[i] == '{' || input[i] == '[' || input[i] == '(') 
                {
                    sequence.Push(input[i]);
                }
                else
                {
                    if (input[i] == '}')
                    {
                        if (sequence.Peek() != '{')
                        {
                            Console.WriteLine("NO");
                            return;
                        }
                        else
                        {
                            sequence.Pop();
                        }
                    }
                    if (input[i] == ')')
                    {
                        if (sequence.Peek() != '(')
                        {
                            Console.WriteLine("NO");
                            return;
                        }
                        else
                        {
                            sequence.Pop();
                        }
                    }
                    if (input[i] == ']')
                    {
                        if (sequence.Peek() != '[')
                        {
                            Console.WriteLine("NO");
                            return;
                        }
                        else
                        {
                            sequence.Pop();
                        }
                    }
                }
            }

            Console.WriteLine("YES");
        }
    }
}
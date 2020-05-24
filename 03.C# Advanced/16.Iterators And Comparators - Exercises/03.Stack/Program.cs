using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Stack
{
    public class Program
    {
        static void Main(string[] args)
        {
            CustomStack<string> stack = new CustomStack<string>();

            string input = Console.ReadLine();
            while (input != "END")
            {
                string[] splitInput = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = splitInput[0];

                if (command == "Push")
                {
                    string[] stuffToAdd = input.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                        .Skip(1)
                        .ToArray();
                    stack.Push(stuffToAdd);
                }
                else if (command == "Pop")
                {
                    if (stack.Count == 0)
                    {
                        Console.WriteLine($"No elements");
                    }
                    else
                    {
                        stack.Pop();
                    }
                }

                input = Console.ReadLine();
            }

            foreach (var element in stack)
            {
                
                Console.WriteLine(element.Replace(',', ' '));
            }
            foreach (var element in stack)
            {
                
                Console.WriteLine(element.Replace(',', ' '));
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem_9._Simple_Text_Editor
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            Stack<string> operations = new Stack<string>();
            StringBuilder answer = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                string[] tokens = Console.ReadLine().Split();
                string command = tokens[0];
                if (command == "1")
                {
                    operations.Push(answer.ToString());
                    string textToAdd = tokens[1];
                    answer.Append(textToAdd);                                                                     
                }

                if (command == "2")
                {
                    int charsToRemove = int.Parse(tokens[1]);
                    operations.Push(answer.ToString());
                    answer.Remove(answer.Length - charsToRemove, charsToRemove);
                }

                if (command == "3")
                {
                    int index = int.Parse(tokens[1]);
                    if (index <= answer.Length)
                    {
                        Console.WriteLine(answer[index - 1]);
                    }                    
                }

                if (command == "4")
                {
                    answer.Clear();
                    string stuffToPush = operations.Pop();
                    answer.Append(stuffToPush);
                }
            }
        }
    }
}

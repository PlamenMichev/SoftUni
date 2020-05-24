using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace Problem_8._Anonymous_Threat
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine()
                .Split()
                .ToList();
            
            while (true)
            {
                string[] tokens = Console.ReadLine()
                    .Split();
                if (tokens[0] == "3:1")
                {
                    break;
                }
                string command = tokens[0];
                if (command == "merge")
                {
                    int startIndex = int.Parse(tokens[1]);
                    int endIndex = int.Parse(tokens[2]);

                    if (startIndex > input.Count - 1 || endIndex < 0)
                    {
                        continue;
                    }

                    if (startIndex < 0)
                    {
                        startIndex = 0;
                    }

                    if (endIndex >= input.Count)
                    {
                        endIndex = input.Count - 1;
                    }

                    Merge(input, startIndex, endIndex);

                }
                else
                {
                    int index = int.Parse(tokens[1]);
                    int parts = int.Parse(tokens[2]);

                    string element = input[index];
                    input.RemoveAt(index);
                    List<string> newWords = Divide(element, parts);
                    input.InsertRange(index, newWords);
                }
            }

            Console.WriteLine(string.Join(" ", input));
        }

        private static List<string> Divide(string element, int parts)
        {
            List<string> newWords = new List<string>();
            int partLength = element.Length / parts;
            int lastPartLength = partLength + element.Length % parts;
            for (int i = 0; i < parts; i++)
            {
                string newWord = element.Substring(i * partLength, partLength);
                if (i == parts - 1)
                {
                    newWord = element.Substring(i * partLength);
                }
                newWords.Add(newWord);
            }
            return newWords;
        }

        private static List<string> Merge(List<string> input, int startIndex, int endIndex)
        {
            StringBuilder saveList = new StringBuilder();
            for (int i = startIndex; i <= endIndex; i++)
            {
                string word = input[i];

                saveList.Append(word);
            }
            input.RemoveRange(startIndex, endIndex - startIndex + 1);
            input.Insert(startIndex, saveList.ToString());
            return input;
        }
    }
}

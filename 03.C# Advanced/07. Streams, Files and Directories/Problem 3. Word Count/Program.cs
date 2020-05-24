using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Problem_3._Word_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = File.ReadAllText(@"Resources/03. Word Count/words.txt");
            string[] words = input.Split();
            var dict = new Dictionary<string, int>();
            foreach (var word in words)
            {
                if (!dict.ContainsKey(word))
                {
                    dict[word] = 0;
                }
            }
            string[] text = File.ReadAllLines(@"Resources/03. Word Count/text.txt");
            for (int i = 0; i < text.Length; i++)
            {
                string[] line = text[i]
                    .Split(new char[]{' ', '-', '.', '?', '!', ','}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x.ToLower())
                    .ToArray();
                foreach (var word in line)
                {
                    if (dict.ContainsKey(word))
                    {
                        dict[word]++;
                    }
                }
            }

            foreach (var kvp in dict.OrderByDescending(x => x.Value))
            {
                using (StreamWriter writer = File.AppendText(@"C:\Users\miche\source\repos\07. Streams, Files and Directories\Problem 3. Word Count\bin\Debug\netcoreapp2.1\Resources\03. Word Count/Output.txt"))
                {
                    writer.WriteLine($"{kvp.Key} - {kvp.Value}");
                }
            }
            
        }
    }
}

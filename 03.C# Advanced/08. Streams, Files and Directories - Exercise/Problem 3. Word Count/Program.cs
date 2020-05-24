using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;

namespace Problem_3._Word_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> words = new List<string>();
            Dictionary<string, int> wordsCount = new Dictionary<string, int>();
            using (var reader = new StreamReader(@"../../../Resources/words.txt"))
            {
                while (true)
                {
                    string line = reader.ReadLine();
                    if (line == null)
                    {
                        break;
                    }

                    words.Add(line);
                }
            }

            foreach (var word in words)
            {
                if (!wordsCount.ContainsKey(word))
                {
                    wordsCount[word] = 0;
                }
            }

            using (var reader = new StreamReader(@"../../../Resources/text.txt"))
            {
                while (true)
                {

                    string temp = reader.ReadLine();
                    if (temp == null)
                    {
                        break;
                    }

                    string symbols = " ";
                    foreach (var symbol in temp)
                    {
                        if (char.IsPunctuation(symbol) && symbol != '\'')
                        {
                            symbols += symbol;
                        }
                    }

                    string[] line = temp
                        .Split(symbols.ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                        .Select(x => x.ToLower())
                        .ToArray();
                    foreach (var word in line)
                    {
                        if (wordsCount.ContainsKey(word))
                        {
                            wordsCount[word]++;
                        }
                    }
                }
            }


            using (var writer = new StreamWriter("../../../Resources//actualResult.txt"))
            {
                foreach (var kvp in wordsCount.OrderByDescending(x => x.Value))
                {
                    writer.WriteLine($"{kvp.Key} - {kvp.Value}");
                }
            }

            var sortedDictionary = wordsCount
                .OrderByDescending(x => x.Value)
                .ToDictionary(x => x.Key, x => x.Value);
            using (var reader = new StreamReader("../../../Resources/expectedResult.txt"))
            {
                bool isSame = true;
                foreach (var kvp in sortedDictionary)
                {
                    string line = reader.ReadLine();
                    string output = $"{kvp.Key} - {kvp.Value}";
                    if (output != line)
                    {
                        isSame = false;
                    }
                }

                if (isSame)
                {
                    Console.WriteLine(true);
                }
            }

            
        }
    }
}

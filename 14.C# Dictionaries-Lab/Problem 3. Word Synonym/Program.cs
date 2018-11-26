using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_3._Word_Synonym
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            var words = new Dictionary<string, List<string>>();
            for (int i = 0; i < num; i++)
            {
                string word = Console.ReadLine();
                string synonym = Console.ReadLine();
                
                if (!words.ContainsKey(word))
                {
                    words.Add(word, new List<string>());
                }
                
                words[word].Add(synonym);
            }

            foreach (var kvp in words)
            {
                Console.WriteLine(kvp.Key + " - " + string.Join(" ", kvp.Value));
            }
        }
    }
}

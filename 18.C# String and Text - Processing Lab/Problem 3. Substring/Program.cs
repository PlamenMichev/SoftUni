using System;

namespace Problem_3._Substring
{
    class Program
    {
        static void Main(string[] args)
        {
            string wordToFind = Console.ReadLine();
            string lineToSearch = Console.ReadLine();
            wordToFind = wordToFind.ToLower();
            lineToSearch = lineToSearch.ToLower();
            while (lineToSearch.Contains(wordToFind))
            {
                int index = lineToSearch.IndexOf(wordToFind);
                lineToSearch = lineToSearch.Remove(index, wordToFind.Length);
            }

            Console.WriteLine(lineToSearch);
        }
    }
}

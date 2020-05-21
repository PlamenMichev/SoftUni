using System;

namespace Equal_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstWord = Console.ReadLine();
            string secWord = Console.ReadLine();
            firstWord = firstWord.ToLower();
            secWord = secWord.ToLower();
            if(firstWord==secWord)
            {
                Console.WriteLine("yes");
            }
            else Console.WriteLine("no");
        }
    }
}

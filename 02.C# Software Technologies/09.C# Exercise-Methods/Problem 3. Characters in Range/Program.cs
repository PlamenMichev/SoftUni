using System;

namespace Problem_3._Characters_in_Range
{
    class Program
    {
        static void Main(string[] args)
        {
            char firstChar = char.Parse(Console.ReadLine());
            char secChar = char.Parse(Console.ReadLine());
            CharactersInRange(firstChar, secChar);
        }
        static void CharactersInRange(char firstChar, char secChar)
        {
            if(secChar < firstChar)
            {
                char x = firstChar;
                firstChar = secChar;
                secChar = x;
            }
            for (int i = firstChar+1; i < secChar; i++)
            {
                if(i == secChar-1)
                {
                    Console.WriteLine((char)i+" ");
                }
                else Console.Write((char)i+" ");
            }
        }
    }
}

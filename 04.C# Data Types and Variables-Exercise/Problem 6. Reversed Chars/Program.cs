using System;

namespace Problem_6._Reversed_Chars
{
    class Program
    {
        static void Main(string[] args)
        {
            char firstChar = char.Parse(Console.ReadLine());
            char secChar = char.Parse(Console.ReadLine());
            char thirdChar = char.Parse(Console.ReadLine());

            Console.Write(thirdChar+" ");
            Console.Write(secChar+" ");           
            Console.WriteLine(firstChar);
        }
    }
}

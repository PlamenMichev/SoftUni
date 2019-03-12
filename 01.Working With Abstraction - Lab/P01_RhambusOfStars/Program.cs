using System;

namespace P01_RhambusOfStars
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            PrintTriangle(length);
            PrintReversedTriangle(length);

        }
        public static void PrintTriangle(int length)
        {
            int secLength = length;
            for (int j = 1; j < length; j++)
            {
                for (int k = 1; k <= secLength - 1; k++)
                {
                    Console.Write(" ");
                }
                secLength--;
                for (int i = 1; i < j + 1; i++)
                {               
                    Console.Write($"* ");
                }
                Console.WriteLine();
            }        
        }
        public static void PrintReversedTriangle(int length)
        {
            int secLength = length;
            for (int j = length; j >= 1; j--)
            {
                for (int k = 1; k <= length - j; k++)
                {
                    Console.Write(" ");
                }
                secLength--;
                for (int i = 1; i < j + 1; i++)
                {
                    Console.Write("* ");
                }
                Console.WriteLine();
            }
            
        }
    }
}

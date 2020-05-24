using System;
using System.Linq;

namespace Problem_6._Even_and_Odd_Subtraction
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int length = numbers.Length;
            int sumOfEven = 0;
            int sumOfOdd = 0;
            for (int i = 0; i < length; i++)
            {
                if (numbers[i] % 2 == 0)
                {
                    sumOfEven += numbers[i];
                }
                else sumOfOdd += numbers[i];
            }
            Console.WriteLine(sumOfEven-sumOfOdd);
        }
    }
}

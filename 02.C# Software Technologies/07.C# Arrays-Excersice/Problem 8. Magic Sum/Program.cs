using System;
using System.Linq;

namespace Problem_8._Magic_Sum
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
            int num = int.Parse(Console.ReadLine());
            for (int i = 0; i < length; i++)
            {
                for (int j = i+1; j < length; j++)
                {
                    if(numbers[i]+numbers[j]==num)
                    {
                        Console.WriteLine(numbers[i]+" "+numbers[j]);
                    }
                }

            }
        }
    }
}

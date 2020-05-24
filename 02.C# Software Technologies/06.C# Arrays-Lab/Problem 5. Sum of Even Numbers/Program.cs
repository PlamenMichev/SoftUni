using System;
using System.Linq;

namespace Problem_5._Sum_of_Even_Numbers
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
            int sum = 0;
            for (int i = 0; i < length; i++)
            {
                if(numbers[i]%2==0)
                {
                    sum += numbers[i];
                }
            }
            Console.WriteLine(sum);
        }
    }
}

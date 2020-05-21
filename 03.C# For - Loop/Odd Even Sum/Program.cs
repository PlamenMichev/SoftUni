using System;

namespace Odd_Even_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            int evenSum = 0;
            int oddSum = 0;
            for (int i = 1; i <= length; i++)
            {
                int num = int.Parse(Console.ReadLine());
                if (i % 2 == 0)
                {
                    evenSum += num;
                }
                else oddSum += num;
            }
            if(evenSum==oddSum)
            {
                Console.WriteLine($"Yes sum = {evenSum}");
            }
            else Console.WriteLine($"No Diff = {Math.Abs(evenSum-oddSum)}");
        }

    }
}

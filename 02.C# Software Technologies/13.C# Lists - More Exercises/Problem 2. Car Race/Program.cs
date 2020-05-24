using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_2._Car_Race
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            double firstPlayerTime = 0;
            double secPlayerTime = 0;
            int length = numbers.Count;

            for (int i = 0; i < length / 2; i++)
            {
                if (numbers[i] == 0)
                {
                    firstPlayerTime = 0.8 * firstPlayerTime;
                    
                }

                else firstPlayerTime += numbers[i];

                if (numbers[length - i - 1] == 0)
                {
                    secPlayerTime = 0.8 * secPlayerTime;
                }
                else secPlayerTime += numbers[length - i - 1];
            }

            if (firstPlayerTime <= secPlayerTime)
            {
                Console.WriteLine($"The winner is left with total time: {firstPlayerTime}");
            }
            else
            {
                Console.WriteLine($"The winner is right with total time: {secPlayerTime}");
            }

        }
    }
}

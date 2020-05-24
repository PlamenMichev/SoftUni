using System;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;

namespace Problem_3._Baking_Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            int bestSum = -50;
            int average = 0;
            int bestLength = 11;
            int[] bestNumbers = new int[11];
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Bake It!")
                {
                    break;
                }
                int[] numbers = input.Split("#")
                    .Select(int.Parse)
                    .ToArray();
                int length = numbers.Length;
                int currentSum = 0;
                for (int i = 0; i < length; i++)
                {
                    currentSum += numbers[i];
                }
                int currentAverage = currentSum / length;
                if (currentSum > bestSum)
                {
                    average = currentAverage;
                    bestSum = currentSum;
                    bestLength = length;

                    bestNumbers = numbers;
                }
                else if (currentSum == bestSum)
                {
                    if (currentAverage > average)
                    {
                        average = currentAverage;
                        bestSum = currentSum;
                        bestLength = length;

                        bestNumbers = numbers;
                    }
                    else if(currentAverage == average)
                    {
                        if (length < bestLength)
                        {
                             average = currentAverage;
                             bestSum = currentSum;
                             bestLength = length;

                             bestNumbers = numbers;
                        }
                    }

                }
            }

            Console.WriteLine($"Best Batch quality: {bestSum}");
            Console.WriteLine(string.Join(" ", bestNumbers));
        }
    }
}

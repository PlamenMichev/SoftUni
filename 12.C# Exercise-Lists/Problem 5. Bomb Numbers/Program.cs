using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_5._Bomb_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            int[] inputs = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int bombNumber = inputs[0];
            int bombPower = inputs[1];
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] == bombNumber)
                {
                    int startIndex = i - bombPower;
                    int endIndex = i + bombPower;
                    if (startIndex < 0)
                    {
                        startIndex = 0;
                    }

                    if (endIndex >= numbers.Count)
                    {
                        endIndex = numbers.Count - 1;
                    }

                    if (endIndex < 0)
                    {
                        continue;
                    }

                    if (startIndex >= numbers.Count)
                    {
                        continue;
                        
                    }
                    numbers.RemoveRange(startIndex, endIndex - startIndex + 1);
                    i = startIndex - 1;
                }
            }

            int sum = numbers.Sum();
            
            Console.WriteLine(sum);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_4._Find_Even_or_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int, bool> isEven = n => n % 2 == 0;
            int[] range = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int lowerNum = range[0];
            int higherNum = range[1];
            string command = Console.ReadLine();
            var answer = new List<int>();
            if (command == "even")
            {
                for (int i = lowerNum; i <= higherNum; i++)
                {
                    if (isEven(i))
                    {
                        answer.Add(i);
                    }
                }
            }
            else
            {
                for (int i = lowerNum; i <= higherNum; i++)
                {
                    if (isEven(i) == false)
                    {
                        answer.Add(i);
                    }
                }
            }
            Console.WriteLine(string.Join(" ", answer));
        }
    }
}

using System;
using System.Linq;

namespace Problem_4._Largest_3_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int[] sorted = numbers
                .OrderByDescending(x => x)
                .ToArray();
            for (int i = 0; i < 3; i++)
            {
                if (i >= sorted.Length)
                {
                    break;
                }

                
                else Console.Write(sorted[i] + " ");
            }
        }
    }
}

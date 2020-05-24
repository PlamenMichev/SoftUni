using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_1._Basic_Stack_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            Stack<int> numbers = new Stack<int>();
            int[] input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int numsToPush = nums[0];
            for (int i = 0; i < numsToPush; i++)
            {
                numbers.Push(input[i]);
            }

            int numsToPop = nums[1];
            for (int i = 0; i < numsToPop; i++)
            {
                numbers.Pop();
            }

            int numToFind = nums[2];
            if (numbers.Any() == false)
            {
                Console.WriteLine("0");
                return;
            }
            if (numbers.Contains(numToFind))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(numbers.Min());
            }
        }
    }
}

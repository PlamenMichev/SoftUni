using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_5._Fashion_Boutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int rackCapacity = int.Parse(Console.ReadLine());
            Stack<int> numbers = new Stack<int>(input);
            int sum = numbers.Pop();
            int result = 0;
            while (numbers.Any())
            {
                if (sum + numbers.Peek() == rackCapacity)
                {
                    numbers.Pop();
                    sum = 0;
                    result++;
                }
                else if (sum + numbers.Peek() > rackCapacity && numbers.Any())
                {
                    sum = 0;
                    result++;
                }
                if (numbers.Count == 1 && numbers.Any())
                {
                    result++;
                }

                if (numbers.Any())
                {
                    sum += numbers.Pop();
                }
                
                
            }
            Console.WriteLine(result);
        }
    }
}

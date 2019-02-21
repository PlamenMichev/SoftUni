using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.TheKitchen
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] knivesInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] forksInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Stack<int> knives = new Stack<int>(knivesInput);
            Queue<int> forks = new Queue<int>(forksInput);
            List<int> sets = new List<int>();
            while (knives.Count != 0 && forks.Count != 0)
            {
                int knifeValue = knives.Peek();
                int forkValue = forks.Peek();
                if (knifeValue > forkValue)
                {
                    int setValue = knifeValue + forkValue;
                    sets.Add(setValue);
                    knives.Pop();
                    forks.Dequeue();
                }
                else if(forkValue > knifeValue)
                {
                    knives.Pop();
                }
                else if(forkValue == knifeValue)
                {
                    forks.Dequeue();
                    knifeValue++;
                    knives.Pop();
                    knives.Push(knifeValue);
                }
            }

            Console.WriteLine($"The biggest set is: {sets.Max()}");
            Console.WriteLine(string.Join(" ", sets));
        }
    }
}

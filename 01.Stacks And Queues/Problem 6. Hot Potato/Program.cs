using System;
using System.Collections.Generic;

namespace Problem_5._Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            Queue<string> names = new Queue<string>(input);
            int num = int.Parse(Console.ReadLine());
            int count = 1;
            while (names.Count > 1)
            {
                string currentName = names.Dequeue();
                if (count % num != 0)
                {
                    names.Enqueue(currentName);
                }

                else
                {
                    Console.WriteLine($"Removed {currentName}");
                }
                count++;
            }

            Console.WriteLine($"Last is {names.Dequeue()}");
        }
    }
}

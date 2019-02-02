using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_3._Periodic_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            HashSet<string> elements = new HashSet<string>();
            for (int i = 0; i < length; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < input.Length; j++)
                {
                    elements.Add(input[j]);
                }
            }

            Console.WriteLine(string.Join(" ", elements.OrderBy(x => x)));

        }
    }
}

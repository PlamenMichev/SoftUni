using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_7.__Append_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split('|', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            var numbers = new List<int>();
            Array.Reverse(input);
            foreach (var token in input)
            {
                string[] num = token.Split(' ');
                foreach (var item in num)
                {
                    if (item != "")
                    {
                        numbers.Add(int.Parse(item));
                    }
                }
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}

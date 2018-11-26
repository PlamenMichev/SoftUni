using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_1._Train
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            int maxCapacity = int.Parse(Console.ReadLine());
            while (true)
            {
                string input = Console.ReadLine();
                if(input == "end")
                {
                    break;
                }
                string[] tokens = input.Split();
                if(tokens[0] == "Add")
                {
                    numbers.Add(int.Parse(tokens[1]));
                }
                else
                {
                    int num = int.Parse(tokens[0]);
                    for (int i = 0; i < numbers.Count; i++)
                    {
                        if (num + numbers[i] <= maxCapacity)
                        
                        {
                            numbers[i] += num;
                            break;
                        }
                    }
                }

            }
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}

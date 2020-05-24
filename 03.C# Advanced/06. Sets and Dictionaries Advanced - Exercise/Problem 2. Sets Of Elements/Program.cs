using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_2._Sets_Of_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int firstSetLength = input[0];
            int secSetLength = input[1];
            HashSet<int> firstSet = new HashSet<int>();
            HashSet<int> secSet = new HashSet<int>();
            List<int> allNumbers = new List<int>();
            HashSet<int> answer = new HashSet<int>();
            for (int i = 0; i < firstSetLength; i++)
            {

                int temp = int.Parse(Console.ReadLine());
                allNumbers.Add(temp);
                firstSet.Add(temp);
            }

            for (int i = 0; i < secSetLength; i++)
            {
                int temp = int.Parse(Console.ReadLine());
                allNumbers.Add(temp);
                secSet.Add(temp);
            }

            foreach (var number in allNumbers)
            {
                if (firstSet.Contains(number) && secSet.Contains(number))
                {
                    answer.Add(number);
                }
            }

            Console.WriteLine(string.Join(" ", answer));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_1._Messeging
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();
            string inputAsString = Console.ReadLine();
            List<string> newWords = new List<string>();
            List<char> input = new List<char>();
            input.AddRange(inputAsString);
            for (int i = 0; i < numbers.Count; i++)
            {
                string newWord = "";
                int sum = FindingSum(numbers[i]);
                if (sum <= input.Count)
                {
                    newWord = Convert.ToString(input[sum]);
                    input.RemoveAt(sum);
                }
                else
                {
                    sum -= input.Count;
                    newWord = Convert.ToString(input[sum]);
                    input.RemoveAt(sum);
                }


                newWords.Add(newWord);
            }

            Console.WriteLine(string.Join("", newWords));
        }

        static int FindingSum(int num)
        {
            int sum = 0;
            while (num != 0)
            {
                sum += num % 10;
                num /= 10;
            }

            return sum;
        }
    }
}

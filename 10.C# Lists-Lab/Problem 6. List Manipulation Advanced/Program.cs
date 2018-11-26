using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_6._List_Manipulation_Advanced
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            bool change = false;
            while (true)
            {
                string input = Console.ReadLine();
                if(input == "end")
                {
                    break;
                }
                string[] tokens = input.Split();
                string command = tokens[0];
                switch (command)
                {
                    case "Contains":
                        int num = int.Parse(tokens[1]);
                        bool isTrue = numbers.Contains(num);
                        if (isTrue)
                        {
                            Console.WriteLine("Yes");
                        }
                        else Console.WriteLine("No such number");
                        break;
                    case "PrintEven":
                        PrintEven(numbers);
                        break;
                    case "PrintOdd":
                        PrintOdd(numbers);
                        break;
                    case "GetSum":
                        GetSum(numbers);
                        break;
                    case "Filter":
                        string condition = tokens[1];
                        int comparableNum = int.Parse(tokens[2]);
                        Filter(condition, comparableNum, numbers);
                        break;
                    case "Add":
                        int numToAdd = int.Parse(tokens[1]);
                        numbers.Add(numToAdd);
                        change = true;
                        break;
                    case "Remove":
                        int numberToRemove = int.Parse(tokens[1]);
                        numbers.Remove(numberToRemove);
                        change = true;
                        break;
                    case "RemoveAt":
                        int position = int.Parse(tokens[1]);
                        numbers.RemoveAt(position);
                        change = true;
                        break;
                    case "Insert":
                        int numberToInsert = int.Parse(tokens[1]);
                        int indexToInsert = int.Parse(tokens[2]);
                        numbers.Insert(indexToInsert, numberToInsert);
                        change = true;
                        break;

                }
            }
            if (change == true)
            {
                Console.WriteLine(string.Join(" ", numbers));
            }
        }

        private static void Filter(string condition, int comparableNum, List<int> numbers)
        {
            List<int> resultNums = new List<int>();
            if(condition == ">")
            {
                for (int i = 0; i < numbers.Count; i++)
                {
                    if(numbers[i] > comparableNum)
                    {
                        resultNums.Add(numbers[i]);
                    }
                }
            }
            else if (condition == "<")
            {
                for (int i = 0; i < numbers.Count; i++)
                {
                    if (numbers[i] < comparableNum)
                    {
                        resultNums.Add(numbers[i]);
                    }
                }
            }
            else if (condition == ">=")
            {
                for (int i = 0; i < numbers.Count; i++)
                {
                    if (numbers[i] >= comparableNum)
                    {
                        resultNums.Add(numbers[i]);
                    }
                }
            }
            else if (condition == "<=")
            {
                for (int i = 0; i < numbers.Count; i++)
                {
                    if (numbers[i] <= comparableNum)
                    {
                        resultNums.Add(numbers[i]);
                    }
                }
            }
            Console.WriteLine(string.Join(" ", resultNums));
        }

        private static void GetSum(List<int> numbers)
        {
            int sum = 0;
            for (int i = 0; i < numbers.Count; i++)
            {
                sum += numbers[i];
            }
            Console.WriteLine(sum);
        }

        private static void PrintOdd(List<int> numbers)
        {
            List<int> oddNumbers = new List<int>();
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] % 2 == 1)
                {
                    oddNumbers.Add(numbers[i]);
                }
            }
            Console.WriteLine(string.Join(" ", oddNumbers));
        }

        private static void PrintEven(List<int> numbers)
        {
            List<int> evenNumbers = new List<int>();
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] % 2 == 0)
                {
                    evenNumbers.Add(numbers[i]);
                }
            }
            Console.WriteLine(string.Join(" ", evenNumbers));
        }
    }
}

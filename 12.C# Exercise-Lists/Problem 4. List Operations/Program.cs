using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_4._List_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            while (true)
            {
                string input = Console.ReadLine();
                if(input == "End")
                {
                    break;
                }
                string[] tokens = input.Split();
                string command = tokens[0];
                if(command == "Add")
                {
                    numbers.Add(int.Parse(tokens[1]));
                }
                if(command == "Insert")
                {
                    int number = int.Parse(tokens[1]);
                    int index = int.Parse(tokens[2]);
                    if(index >= numbers.Count || index < 0)
                    {
                        Console.WriteLine("Invalid index");
                        continue;
                    }
                    numbers.Insert(index, number);
                }
                if(command == "Remove")
                {
                    int index = int.Parse(tokens[1]);
                    if (index >= numbers.Count || index < 0)
                    {
                        Console.WriteLine("Invalid index");
                        continue;
                    }
                    numbers.RemoveAt(index);
                }
                if(tokens[1] == "left")
                {
                    int count = int.Parse(tokens[2]);
                    int length = numbers.Count;
                    for (int i = 0; i < count % numbers.Count; i++)
                    {
                        numbers.Add(numbers[0]);
                        numbers.RemoveAt(0);
                    }

                }
                if(tokens[1] == "right")
                {
                    int count = int.Parse(tokens[2]);
                    int length = numbers.Count;
                    for (int i = 0; i < count % numbers.Count; i++)
                    {
                        int lastNum = numbers[numbers.Count - 1];
                        for (int j = numbers.Count - 1; j > 0; j--)
                        {
                            numbers[j] = numbers[j - 1];
                        }

                        numbers[0] = lastNum;
                    }
                }

            }
                Console.WriteLine(string.Join(" ", numbers));
        }
    }
}

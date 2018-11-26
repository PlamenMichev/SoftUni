using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_2._Change_List
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
                if(input == "end")
                {
                    break;
                }
                string[] tokens = input.Split();
                string command = tokens[0];
                if(command == "Delete")
                {
                    int elementToDelete = int.Parse(tokens[1]);

                    for (int i = 0; i < numbers.Count; i++)
                    {
                        if(numbers[i] == elementToDelete)
                        {
                            numbers.Remove(elementToDelete);
                            i = -1;
                        }
                    }
                }
                else if(command == "Insert")
                {
                    int element = int.Parse(tokens[1]);
                    int position = int.Parse(tokens[2]);
                    numbers.Insert(position, element);
                }

            }
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}

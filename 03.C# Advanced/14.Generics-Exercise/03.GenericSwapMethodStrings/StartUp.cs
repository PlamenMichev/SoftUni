﻿using System;
using System.Linq;

namespace _03.GenericSwapMethodStrings
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Box<string> box = new Box<string>();
            int length = int.Parse(Console.ReadLine());
            for (int i = 0; i < length; i++)
            {
                string input = Console.ReadLine();
                box.Add(input);
            }

            int[] indexes = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            box.Swap(indexes[0], indexes[1]);
            Console.WriteLine(box);
        }
    }
}

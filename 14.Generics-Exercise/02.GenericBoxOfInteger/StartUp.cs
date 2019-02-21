using System;
using System.Collections.Generic;

namespace _01.GenericsBoxOfString
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Box<int> box = new Box<int>();
            int length = int.Parse(Console.ReadLine());
            for (int i = 0; i < length; i++)
            {
                int input = int.Parse(Console.ReadLine());
                box.Add(input);
            }

            Console.WriteLine(box);
        }
    }
}

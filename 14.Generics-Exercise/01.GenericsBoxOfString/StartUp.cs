using System;
using System.Collections.Generic;

namespace _01.GenericsBoxOfString
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

            Console.WriteLine(box);
        }
    }
}

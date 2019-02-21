using System;
using _03.GenericSwapMethodStrings;

namespace _05.GenericCountMethodStrings
{
    public class Program
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

            string numToCompare = Console.ReadLine();
            Console.WriteLine(box.GreaterNums(numToCompare));
        }
    }
}

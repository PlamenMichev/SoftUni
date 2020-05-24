using System;
using _03.GenericSwapMethodStrings;

namespace _05.GenericCountMethodStrings
{
    public class Program
    {
        static void Main(string[] args)
        {
            Box<double> box = new Box<double>();
            int length = int.Parse(Console.ReadLine());

            for (int i = 0; i < length; i++)
            {
                double input = double.Parse(Console.ReadLine());
                box.Add(input);
            }

            double numToCompare = double.Parse(Console.ReadLine());
            Console.WriteLine(box.GreaterNums(numToCompare));
        }
    }
}

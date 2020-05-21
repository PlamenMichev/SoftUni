using System;

namespace Inches_to_Centimeters
{
    class Program
    {
        static void Main(string[] args)
        {
            double numInInches = double.Parse(Console.ReadLine());
            double numToCentimeters = numInInches * 2.54;
            Console.WriteLine($"{numToCentimeters:F2}");
        }
    }
}

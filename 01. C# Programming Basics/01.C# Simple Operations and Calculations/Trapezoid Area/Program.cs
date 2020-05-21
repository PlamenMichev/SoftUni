using System;

namespace Trapezoid_Area
{
    class Program
    {
        static void Main(string[] args)
        {
            double firstBase = double.Parse(Console.ReadLine());
            double secBase = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            double area = (firstBase + secBase) * height / 2;
            Console.WriteLine($"{area:F2}");
        }
    }
}

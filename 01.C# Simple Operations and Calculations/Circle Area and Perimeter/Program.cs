using System;

namespace Circle_Area_and_Perimeter
{
    class Program
    {
        static void Main(string[] args)
        {
            double radius = double.Parse(Console.ReadLine());
            double area = Math.PI * radius * radius;
            double perimeter = 2 * Math.PI * radius;
            Console.WriteLine($"{area}");
            Console.WriteLine($"{perimeter}");
        }
    }
}

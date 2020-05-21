using System;

namespace Square_Area
{
    class Program
    {
        static void Main(string[] args)
        {
            double firstNum = double.Parse(Console.ReadLine());
            double result = firstNum * firstNum;
            Console.WriteLine($"{result:F2}");
        }
    }
}

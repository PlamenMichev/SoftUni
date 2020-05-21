using System;

namespace Celsius_to_Fehrenheit
{
    class Program
    {
        static void Main(string[] args)
        {
            double celsius = double.Parse(Console.ReadLine());
            double fahrenheit = (celsius * 1.8) + 32;
            Console.WriteLine($"{fahrenheit:F2}");
        }
    }
}

using System;

namespace Problem_5._Pounds_to_Dollars
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal pounds = decimal.Parse(Console.ReadLine());
            Console.WriteLine($"{pounds*1.31m:f3}");
        }
    }
}

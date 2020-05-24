using System;

namespace Problem_4._Convert_Metres_to_Kilometres
{
    class Program
    {
        static void Main(string[] args)
        {
            double metres = double.Parse(Console.ReadLine());
            Console.WriteLine($"{ metres / 1000:f2}");
        }
    }
}

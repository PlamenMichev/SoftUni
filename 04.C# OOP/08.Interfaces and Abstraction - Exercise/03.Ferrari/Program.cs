using System;

namespace _03.Ferrari
{
    public class Program
    {
        static void Main(string[] args)
        {
            string driver = Console.ReadLine();
            var car = new Ferrari(driver);
            Console.WriteLine(car);
        }
    }
}

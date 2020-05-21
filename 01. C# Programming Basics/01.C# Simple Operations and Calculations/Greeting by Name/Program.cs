using System;

namespace Greeting_by_Name
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            Console.Write("Hello, ");
            Console.WriteLine(name+"!");
        }
    }
}
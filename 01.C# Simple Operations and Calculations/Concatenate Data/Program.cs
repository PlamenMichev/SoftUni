using System;

namespace Concatenate_Data
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstName = Console.ReadLine();
            string secName = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string town = Console.ReadLine();
            Console.WriteLine($"You are {firstName} {secName}, a {age}-years old person from {town}.");
        }
    }
}

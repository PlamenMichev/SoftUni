using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace Problem_1._Action_Point
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> print = x => Console.WriteLine(x);
                 Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList()
                .ForEach(print);
        }
    }
}

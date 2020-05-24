using System;
using System.Linq;
using System.Net.Sockets;

namespace Problem_5._Word_Filter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine()
                .Split()
                .Where(w => w.Length % 2 == 0)
                .ToArray();
            Console.WriteLine(string.Join("\n", words));
        }
    }
}

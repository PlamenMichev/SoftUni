using System;
using System.Linq;

namespace Problem_2._Sum_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, int> parser = num => int.Parse(num);
            int[] numbers = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(parser)
                .ToArray();
            Console.WriteLine(numbers.Length);
            Console.WriteLine(numbers.Sum());
        }
    }
}

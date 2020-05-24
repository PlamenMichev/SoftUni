using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Problem_13._TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            Func<string, char[]> funcToCharArr = x => x.ToCharArray();
            Func<char, int> castFunc = x => (int) x;
            Func<string, bool> finalFunc = x => funcToCharArr(x)
                                                    .Select(castFunc)
                                                    .Sum() >= num;
            Console.WriteLine(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .FirstOrDefault(finalFunc));
        }
    }
}

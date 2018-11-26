using System;
using System.Numerics;

namespace Problem_3._Big_Factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            BigInteger fac = 1;
            for (int i = 1; i <= num; i++)
            {
                fac *= i;
            }

            Console.WriteLine(fac);
        }
    }
}

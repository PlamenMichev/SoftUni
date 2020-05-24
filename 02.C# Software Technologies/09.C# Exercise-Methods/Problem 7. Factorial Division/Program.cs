using System;

namespace Problem_7._Factorial_Division
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secNum = int.Parse(Console.ReadLine());
            ReturnDividedFactorials(firstNum, secNum);
        }
        static double FindFactorial(int num)
        {
            double fac = 1;
            for (int i = 1; i <= num; i++)
            {
                fac *= i;
            }
            return fac;
        }
        static void ReturnDividedFactorials(int firstNum, int secNum)
        {
            double answer = FindFactorial(firstNum) / FindFactorial(secNum);
            Console.WriteLine($"{answer:f2}");
        }
    }
}

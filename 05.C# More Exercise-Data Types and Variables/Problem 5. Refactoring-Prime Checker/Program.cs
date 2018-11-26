using System;

namespace Problem_5._Refactoring_Prime_Checker
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            for (int i = 2; i <= num; i++)
            {
                bool check = true;
                for (int j = 2; j < i; j++)
                {
                    if (i % j == 0)
                    {
                        check = false;
                        break;
                    }
                }

                Console.WriteLine($"{i} -> {check.ToString().ToLower()}");
            }

        }
    }
}

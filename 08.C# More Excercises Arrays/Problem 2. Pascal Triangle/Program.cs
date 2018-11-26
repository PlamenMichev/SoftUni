using System;

namespace Problem_2._Pascal_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            int[] nums = new int[length];
            int num = 1;
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    if (i == 0 || j == 0)
                    {
                        num = 1;
                    }
                    else
                    {
                        num = num * (i - j - 1) / j;
                    }
                    Console.Write(num+" ");
                }
                Console.WriteLine();
            }
        }
    }
}

using System;

namespace Max_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            int num = int.Parse(Console.ReadLine());
            int min = num;
            for (int i = 0; i < length - 1; i++)
            {
                num = int.Parse(Console.ReadLine());
                if (num <= min)
                {
                    min = num;
                }
            }
            Console.WriteLine(min);
        }
    }
}

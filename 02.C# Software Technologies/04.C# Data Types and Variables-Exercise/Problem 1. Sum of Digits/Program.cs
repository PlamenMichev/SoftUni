    using System;

namespace Problem_1._Sum_of_Digits
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int sum = 0;
            while(num != 0)
            {
                sum += num % 10;
                num = num / 10;
            }
            Console.WriteLine(sum);
        }
    }
}

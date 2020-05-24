using System;

namespace Problem_11._Multiplication_Table_2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int times = int.Parse(Console.ReadLine());
            for(int i=times;i<=10;i++)
            {
                Console.WriteLine($"{num} X {i} = {num*i}");
            }
            if (times > 10)
            {
                Console.WriteLine($"{num} X {times} = {num * times}");
            }
        }
    }
}

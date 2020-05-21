using System;

namespace Account_Balance
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            double payment;
            int i = 0;
            double sum = 0;
            while(i<num)
            {
                payment = double.Parse(Console.ReadLine());
                if (payment >= 0)
                {
                    sum += payment;
                    Console.WriteLine($"Your account balance was increased by: {payment:f2}");
                }
                else
                {
                    Console.WriteLine("Invalid operation!");
                    break;
                }
                i++;
            }
            Console.WriteLine($"Total balance: {sum}");
        }
    }
}

using System;

namespace Number_in_Range_1_to_100_
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            while(num<1 || num>100)
            {
                Console.WriteLine("Invalid Number!");
                num = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("The number is: "+num);
        }
    }
}

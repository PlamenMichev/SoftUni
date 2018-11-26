using System;

namespace Problem_4._Floating_Equality
{
    class Program
    {
        static void Main(string[] args)
        {
            double firstNum = double.Parse(Console.ReadLine());
            double secNum = double.Parse(Console.ReadLine());
            double difference = Math.Abs(firstNum - secNum);
            if(difference>0.000001)
            {
                Console.WriteLine("False");
            }
            else
            {
                Console.WriteLine("True");
            }
        }
    }
}

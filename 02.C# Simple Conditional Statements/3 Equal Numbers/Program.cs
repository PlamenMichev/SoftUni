using System;

namespace _3_Equal_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double firstNum = double.Parse(Console.ReadLine());
            double secNum = double.Parse(Console.ReadLine());
            double thirdNum = double.Parse(Console.ReadLine());
            if(firstNum==secNum && firstNum==thirdNum && thirdNum==secNum)
            {
                Console.WriteLine("yes");
            }
            else Console.WriteLine("no");
        }
    }
}

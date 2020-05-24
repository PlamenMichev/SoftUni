using System;

namespace Problem_1._Smallest_of_Three_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secNum = int.Parse(Console.ReadLine());
            int thirdNum = int.Parse(Console.ReadLine());
            SmallestNum(firstNum, secNum, thirdNum);
        }
        static void SmallestNum(int firstNum, int secNum, int thirdNum)
        {
            int min = firstNum;
            if (min > secNum)
            {
                min = secNum;
            }
            if(min > thirdNum)
            {
                min = thirdNum;
            }
            Console.WriteLine(min);
        }
    }
}

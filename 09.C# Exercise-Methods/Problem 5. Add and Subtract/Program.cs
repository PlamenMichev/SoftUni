using System;

namespace Problem_5._Add_and_Subtract
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secNum = int.Parse(Console.ReadLine());
            int thirdNum = int.Parse(Console.ReadLine());
            int answer = Subtract(thirdNum, secNum, firstNum);
            Console.WriteLine(answer);
        }

        static int Sum(int firstNum, int secNum)
        {
            int sum = firstNum + secNum;
            return sum;
        }
        static int Subtract(int thirdNum, int secNum, int firstNum)
        {
                int subtraction = Sum(firstNum, secNum) - thirdNum;
                return subtraction;
        }
    }
}

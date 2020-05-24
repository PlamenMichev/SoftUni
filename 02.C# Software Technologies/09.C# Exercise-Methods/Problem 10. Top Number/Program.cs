using System;

namespace Problem_10._Top_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            for (int i = 0; i < num; i++)
            {
                if(IsThereOdd(i) == true && ReturnSumOfDigits(i) % 8 == 0)
                {
                    Console.WriteLine(i);
                }
            }
        }
        static int ReturnSumOfDigits(int num)
        {
            int sum = 0;
            while(num != 0)
            {
                sum += num % 10;
                num = num / 10;
            }
            return sum;
        }
        static bool IsThereOdd(int num)
        {
            bool isFalse = true;
            while(num != 0)
            {

                int numToCheck = num % 10;
                num = num / 10;
                if(numToCheck % 2 != 0)
                {
                    isFalse = false;
                    break;
                }
            }
            if (isFalse)
            {
                return false;
            }
            else return true;
        }
    }
}

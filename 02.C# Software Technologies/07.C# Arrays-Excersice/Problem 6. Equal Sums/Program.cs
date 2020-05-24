using System;
using System.Linq;

namespace Problem_6._Equal_Sums
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int answer = -1;
            int leftSum = 0;
            int rightSum = 0;
            int length = numbers.Length;
            for (int i = 0; i < length; i++)
            {
                for (int j = i; j > 0; j--)
                {
                    leftSum += numbers[i-j];
                }
                for (int j = i+1; j < length; j++)
                {
                    rightSum += numbers[j];
                }
                if(leftSum==rightSum)
                {
                    answer = i;
                    break;
                }
                leftSum = 0;
                rightSum = 0;
            }
            if(answer != -1)
            {
                Console.WriteLine(answer);
            }
            else Console.WriteLine("no");
                
        }
    }
}

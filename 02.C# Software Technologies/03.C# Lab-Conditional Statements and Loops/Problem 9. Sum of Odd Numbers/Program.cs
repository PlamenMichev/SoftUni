using System;

namespace Problem_9._Sum_of_Odd_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int sum = 0;
            int count = 0;
            int oddNum = 1;
            while(count<num)
            {
                Console.WriteLine(oddNum);
                count++;
                sum+=oddNum;
                oddNum += 2;
                
            }
            Console.WriteLine($"Sum: {sum}");
        }
    }
}

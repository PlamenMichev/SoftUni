using System;

namespace Problem_6._Strong_Number
{
    class Program
    {
        static int factoroal(int num)
        {
            int fac = 1;
            for (int i = 1; i <= num; i++)
            {
                fac = fac * i;
            }
            return fac;
        }
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int sum = 0;
            if(num<=9)
            {
                sum += factoroal(num);
            }
           else if(num>=10 && num<100)
            {
                int firstNum = num / 10;
                int secondNum = num % 10;
                sum += factoroal(firstNum) + factoroal(secondNum);
            }
           else if(num>=100 && num<1000)
            {
                int firstNum = num / 100;
                int secNum = num / 10 % 10;
                int thirdNum = num % 10;
                sum += factoroal(firstNum) + factoroal(secNum) + factoroal(thirdNum);
            }
            else if(num>=10000 && num<100000)
            {
                int firstNum = num / 10000;
                int secNum = num / 1000 % 10;
                int thirdNum = num / 100 % 10;
                int fourthNum = num / 10 % 10;
                int fifthNum = num % 10;
                sum += factoroal(firstNum) + factoroal(secNum) + factoroal(thirdNum) + factoroal(fourthNum) + factoroal(fifthNum);
            }
            if(num==sum)
            {
                Console.WriteLine("yes");
            }
            else Console.WriteLine("no");
        }
    }
}

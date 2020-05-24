using System;

namespace Problem_2._English_Name_of_The_Last_Digit
{
    class Program
    {
        public static void LastNum(int num)
        {
            string answer = "";
            if (num == 1)
            {
                answer = "one";
            }
            else if (num == 2)
            {
                answer = "two";
            }
            else if (num == 3)
            {
                answer = "three";
            }
            else if (num == 4)
            {
                answer = "four";
            }
            else if (num == 5)
            {
                answer = "five";
            }
            else if (num == 6)
            {
                answer = "six";
            }
            else if(num==7)
            {
                answer = "seven";
            }
            else if(num==8)
            {
                answer = "eight";
            }
            else if(num==9)
            {
                answer = "nine";
            }
            else if(num==0)
            {
                answer = "zero";
            }
            Console.WriteLine(answer);
            }
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int lastNum = num % 10;
            LastNum(lastNum);
        }
    }
}

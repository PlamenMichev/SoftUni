using System;

namespace Problem_9._Palindrome_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine(); 
            int num = int.Parse(input);
            IsPalindrome(num);
            while (true)
            {
                input = Console.ReadLine(); 
                if(input == "END")
                {
                    break;
                }
                num = int.Parse(input);
                IsPalindrome(num);

            }
        }
        static void IsPalindrome(int num)
        {
            string reversedNum = "";
            string saveNum = Convert.ToString(num);
            while(num != 0)
            {
                reversedNum += Convert.ToString(num % 10);
                num = num / 10;
            }
            if (reversedNum == saveNum)
            {
                Console.WriteLine("true");
            }
            else Console.WriteLine("false"); 
        }
    }
}

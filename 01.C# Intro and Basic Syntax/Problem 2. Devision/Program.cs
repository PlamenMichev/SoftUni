using System;

namespace Problem_2._Devision
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int divNum = 0;
          
                
                if (num%2==0)
                {
                    divNum = 2;

                }
                if (num % 3 == 0)
                {
                    divNum = 3;

                }
                if (num % 6 == 0)
                {
                    divNum = 6;

                }
                if (num % 7 == 0)
                {
                    divNum = 7;

                }
                if (num % 10 == 0)
                {
                    divNum = 10;

                }
                if(num%3==0 && num%2==0)
                {
                    divNum = 6;
                }
                if(num%2==0 && num%10==0)
                {
                    divNum = 10;
                }
            
            if(divNum==0)
            {
                Console.WriteLine("Not divisible");
            }
            else Console.WriteLine($"The number is divisible by {divNum}");
        }
    }
}

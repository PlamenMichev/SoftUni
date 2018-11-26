using System;

namespace Problem_2._From_Left_to_The_Right
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int count = 1;

            while(count<=num)
            {
                long sum = 0;
                string[] input = Console.ReadLine().Split();
                long numToCompare = long.Parse(input[0]);
                long secNumToCompare = long.Parse(input[1]);
                if (numToCompare > secNumToCompare)
                {

                    while (numToCompare != 0)
                    {
                        sum += Math.Abs(numToCompare % 10);
                        numToCompare /= 10;
                    }
                    Console.WriteLine(sum);
                }

                else
                {
                    while (secNumToCompare != 0)
                    {
                        sum += Math.Abs(secNumToCompare % 10);
                        secNumToCompare /= 10;
                    }
                    Console.WriteLine(sum);
                }
                count++;
                
            }
            
            
        }
    }
}

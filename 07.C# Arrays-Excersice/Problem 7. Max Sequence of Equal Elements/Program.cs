using System;
using System.Linq;

namespace Problem_7._Max_Sequence_of_Equal_Elements
{
    class Program
    {
        static void Main(string[] args)
            {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int length = numbers.Length;
            int count = 0;
            int saveBiggestNum = 0;
            int biggestCount = 0;
            for (int i = 1; i < length; i++)
            {
                if (numbers[i] == numbers[i - 1])
                {
                    count++;      
                }
                else  count = 0;
                if(count>biggestCount)
                {
                    saveBiggestNum = numbers[i];
                    biggestCount = count;
                }

                
            }
            for (int i = 0; i <= biggestCount; i++)
            {
                Console.Write(saveBiggestNum+" ");
            }
        }
    }
}

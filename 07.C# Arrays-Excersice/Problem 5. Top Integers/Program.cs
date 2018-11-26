using System;
using System.Linq;

namespace Problem_5._Top_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            string bigNums = "";
            
            int length = numbers.Length;
            for (int i = 0; i < length; i++)
            {
                bool isBigger = true;
                for (int j = i+1; j < length; j++)
                {
                    if(numbers[i]<=numbers[j])
                    {
                        isBigger = false;
                    }
                }
                if(isBigger)
                {
                    bigNums += numbers[i].ToString()+" ";
                }
            }
            Console.WriteLine(bigNums);
        }
    }
}

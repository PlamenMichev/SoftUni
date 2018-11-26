using System;
using System.Linq;

namespace Problem_3._Zig_Zag_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            int[] firstArray = new int[length];
            int[] secArray = new int[length];
            for (int i = 0; i < length; i++)
            {
                int[] numbers= Console.ReadLine()
                                .Split()
                                .Select(int.Parse)
                                .ToArray();

                if (i % 2 == 0)
                {
                    firstArray[i] = numbers[0];
                    secArray[i] = numbers[1];
                }
                if (i % 2 == 1)
                {
                    secArray[i] = numbers[0];
                    firstArray[i] = numbers[1];
                }
            }
            for (int i = 0; i < length; i++)
            {
                if(i==length-1)
                {
                    Console.WriteLine(firstArray[i]+" ");
                }
                else Console.Write(firstArray[i]+" ");
            }
            for (int i = 0; i < length; i++)
            {
                Console.Write(secArray[i]+" ");
            }

        }
    }
}

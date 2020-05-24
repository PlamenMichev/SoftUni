using System;
using System.Linq;

namespace Problem_4._Array_Rotation
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int length = int.Parse(Console.ReadLine());
           
            
            Array.Resize(ref numbers, numbers.Length + 1);
            int arrLength = numbers.Length;
            for (int i = 0; i < length; i++)
            {
                numbers[arrLength-1]=numbers[0];
                for (int j = 1; j < arrLength; j++)
                {
                    numbers[j-1] = numbers[j];
                }
                numbers[arrLength-1] = 0;
            }
            for (int i = 0; i < arrLength-1; i++)
            {
                Console.Write(numbers[i]+" ");
            }
        }
    }
}

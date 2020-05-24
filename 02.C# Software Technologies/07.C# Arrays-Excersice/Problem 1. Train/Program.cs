using System;

namespace Problem_1._Train
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            int[] numbers = new int[length];
            int sum = 0;
            for (int i = 0; i < length; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
                sum += numbers[i];
            }
            for (int i = 0; i < length; i++)
            {
                if (i == length - 1)
                {
                    Console.WriteLine(numbers[i]);
                }
                else Console.Write(numbers[i]+" ");
            }
            Console.WriteLine(sum);
        }
    }
}

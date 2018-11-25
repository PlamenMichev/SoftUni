using System;

namespace Problem_4._Print_and_Sum
{
    public class Program
    {
        public static void Main()
        {
            int firstNum = int.Parse(Console.ReadLine());
            int lastNum = int.Parse(Console.ReadLine());
            int sum = 0;
            for(int i=firstNum; i<=lastNum; i++)
            {
                Console.Write(i+" ");
                sum += i;
            }
            Console.WriteLine();
            Console.WriteLine($"Sum: {sum}");
        }
    }
}

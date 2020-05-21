using System;

namespace Half_Sum_Element
{
    class Program
    {
        private static int hui(int length, int max)
        {
            int num = int.Parse(Console.ReadLine());
            max = num;
            for (int i=0; i<length; i++)
            {
                 num = int.Parse(Console.ReadLine());
                if(max>num)
                {
                    max = num;
                }
                return max;
            }
        }

        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            int sum = 0;
            int max = MaxNum(length, int.MaxValue);
            for (int i = 0; i < length; i++)
            {
                int num = int.Parse(Console.ReadLine());
                if (num > max)
                {
                    max = num;
                }
                else sum += num;
            }
            if(max==sum)
            {
                Console.WriteLine($"Yes Sum = {sum}");
            }
            else Console.WriteLine($"No Diff = {Math.Abs(max-sum)}");
        }
    }
}

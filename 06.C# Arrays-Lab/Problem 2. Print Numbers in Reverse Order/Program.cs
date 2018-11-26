using System;

namespace Problem_2._Print_Numbers_in_Reverse_Order
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            int[] nums = new int[length+1];
            for (int i = 0; i < length; i++)
            {
                nums[i] = int.Parse(Console.ReadLine());
            }
            for (int i = length-1; i >= 0; i--)
            {
                if(i==0)
                {
                    Console.WriteLine(nums[i]);
                }
                else Console.Write(nums[i]+" ");

            }
        }
    }
}

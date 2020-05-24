using System;
using System.Linq;
namespace Problem_3._Rounding_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] nums = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToArray();
            int length = nums.Length;
            for (int i = 0; i < length; i++)
            {
                Console.WriteLine($"{nums[i]} => {Math.Round(nums[i], MidpointRounding.AwayFromZero)}");
            }
        }
    }
}

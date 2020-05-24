using System;
using System.Linq;

namespace Problem_1._Encyrupt_Sort_and_Print_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            int finalSum = 0;
            int[] nums = new int[length];
            for (int i = 0; i < length; i++)
            {
                string namesAsArr1 = Console.ReadLine();
                char[] namesAsArr = namesAsArr1
                    .ToArray();
                for (int j = 0; j < namesAsArr.Length; j++)
                {
                    if (namesAsArr[j] == 'a'
                        || namesAsArr[j] == 'A'
                        || namesAsArr[j] == 'e'
                        || namesAsArr[j] == 'E'
                        || namesAsArr[j] == 'u'
                        || namesAsArr[j] == 'U'
                        || namesAsArr[j] == 'O'
                        || namesAsArr[j] == 'o'
                        || namesAsArr[j] == 'i'
                        || namesAsArr[j] == 'I')
                    {
                        finalSum += (int)namesAsArr[j] * namesAsArr.Length;
                    }
                    else
                    {
                        finalSum += (int)namesAsArr[j] / namesAsArr.Length;
                    }
                }
                nums[i] = finalSum;
                finalSum = 0;
            }
            for (int j = 0; j < length; j++)
            {
            for (int i = j+1; i < length; i++)
            {
                if(nums[i]<nums[j])
                {
                        int x = nums[j];
                        nums[j] = nums[i];
                        nums[i] = x;

                }
 }
            }
            Console.WriteLine(string.Join(("\n"), nums ));
        }
    }
}

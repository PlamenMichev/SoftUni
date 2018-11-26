using System;
using System.Collections.Generic;

namespace Problem_5._Multiply_Big_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstNum = Console.ReadLine().TrimStart('0');
            int secNum = int.Parse(Console.ReadLine());
            if (secNum == 0 || firstNum == "0")
            {
                Console.WriteLine(0);
                return;
            }
            List<int> saveProduct = new List<int>(firstNum.Length);
            int left = 0;
            for (int i = 0; i < firstNum.Length; i++)
            {
                char numAsChar = firstNum[firstNum.Length - i - 1];
                int num = (int)Char.GetNumericValue(numAsChar);
                int product = (num * secNum) + left;
                
                left = product / 10;
                int finalProduct = product % 10;
                saveProduct.Add(finalProduct);
                if (i == firstNum.Length - 1 && left != 0)
                {
                    saveProduct.Add(left);
                    break;
                }
            }

            saveProduct.Reverse();
            Console.WriteLine(string.Join("", saveProduct));
        }

    }
}

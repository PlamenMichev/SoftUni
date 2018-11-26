using System;
using System.Linq;

namespace Problem_4._Reverse_Array_of_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split()
                .ToArray();
            int length = input.Length;
            for (int i = length-1; i >= 0; i--)
            {
                if(i==0)
                {
                    Console.WriteLine(input[i]);
                }
                else Console.Write(input[i]+" ");
            }

        }
    }
}

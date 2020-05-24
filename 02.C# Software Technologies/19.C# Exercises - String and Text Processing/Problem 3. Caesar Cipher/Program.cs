using System;

namespace Problem_4._Caesar_Cipher
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string output = "";
            for (int i = 0; i < input.Length; i++)
            {
                char symbol = input[i];
                symbol += (char)3;
                output += symbol;
            }

            Console.WriteLine(output);
        }
    }
}

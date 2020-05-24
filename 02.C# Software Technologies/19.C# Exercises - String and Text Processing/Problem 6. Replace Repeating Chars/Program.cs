using System;

namespace Problem_6._Replace_Repeating_Chars
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int length = input.Length;
            for (int i = 1; i < input.Length; i++)
            {
                if(input[i] == input[i - 1])
                {
                    input = input.Remove(i, 1);
                    i--;
                }
            }

            Console.WriteLine(input);
        }
    }
}

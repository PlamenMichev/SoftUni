using System;

namespace Problem_5._Digits__Letters_and_Others
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string digits = "";
            string letters = "";
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] >= 48 && input[i] <= 57)
                {
                    digits += input[i];
                }
                else if ((input[i] >= 65 && input[i] <= 90) || (input[i] >= 97 && input[i] <= 122))
                {
                    letters += input[i];
                }
            }

            Console.WriteLine(digits);
            Console.WriteLine(letters);
        }
    }
}

using System;

namespace Vowels_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            int sum = 0;
            int length = text.Length - 1;
            for (int i = 0; i <= length; i++)
            {
                if(text[i]=='a')
                {
                    sum += 1;
                }
                if (text[i] == 'e')
                {
                    sum += 2;
                }
                if (text[i] == 'i')
                {
                    sum += 3;
                }
                if (text[i] == 'o')
                {
                    sum += 4;
                }
                if (text[i] == 'u')
                {
                    sum += 5;
                }
            }
            Console.WriteLine(sum);
        }
    }
}

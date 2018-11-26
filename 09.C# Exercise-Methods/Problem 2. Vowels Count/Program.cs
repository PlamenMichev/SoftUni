using System;

namespace Problem_2._Vowels_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            VowelsCount(input);
        }
        static void VowelsCount(string input)
        {
            int count = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if(input[i] == 'a'
                    || input[i] == 'A'
                    || input[i] == 'u' 
                    || input[i] == 'U'
                    || input[i] == 'o'
                    || input[i] == 'e'
                    || input[i] == 'i'
                    || input[i] == 'O'
                    || input[i] == 'E'
                    || input[i] == 'I'
                    )
                {
                    count++;
                }
            }
            Console.WriteLine(count);
        }
    }
}

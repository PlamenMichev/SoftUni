using System;

namespace Problem_7._String_Explosion
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int strength = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '>')
                {
                    strength += (int)Char.GetNumericValue(input[i + 1]);
                    continue;
                }
                if (strength > 0)
                {
                    input = input.Remove(i, 1);
                    i--;
                    strength--;
                }
            }

            Console.WriteLine(input);
        }
    }
}

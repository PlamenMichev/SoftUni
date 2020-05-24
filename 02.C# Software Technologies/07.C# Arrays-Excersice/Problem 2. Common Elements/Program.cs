using System;
using System.Linq;

namespace Problem_2._Common_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split()
                .ToArray();
            string[] secInput = Console.ReadLine()
                .Split()
                .ToArray();
            string common = "";
            int length = input.Length;
            int secLength = secInput.Length;
            for (int i = 0; i < secLength; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if(secInput[i]==input[j])
                    {
                        common += secInput[i] + " ";

                    }
                }
                
            }
            Console.WriteLine(common);
        }
    }
}

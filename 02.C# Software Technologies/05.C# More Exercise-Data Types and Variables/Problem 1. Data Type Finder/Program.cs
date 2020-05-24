using System;

namespace Problem_1._Data_Type_Finder
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            while(input != "END")
            {
                bool isBolean = bool.TryParse(input, out bool bolean);
                bool isDouble = float.TryParse(input, out float doubleNum);
                bool isInt = int.TryParse(input, out int intNum);
                bool isChar = char.TryParse(input, out char character);
                if(isBolean==true)
                {
                    Console.WriteLine($"{input} is boolean type");
                }
                else if (isInt == true)
                {
                    Console.WriteLine($"{input} is integer type");
                }
                else if (isDouble == true)
                {
                    Console.WriteLine($"{input} is floating point type");
                }
                else if (isChar == true)
                {
                    Console.WriteLine($"{input} is character type");
                }
                else Console.WriteLine($"{input} is string type");
                input = Console.ReadLine();
            }
        }
    }
}

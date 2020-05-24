using System;

namespace Problem_6._Middle_Characters
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Console.WriteLine( ReturnMiddleChar(input) ); 
        }
        static string ReturnMiddleChar(string input)
        {
            int length = input.Length;
            string output="";
            if(length % 2 == 0)
            {
                output =  Convert.ToString(input[(length / 2) - 1]) + Convert.ToString(input[length / 2]) ;
            }
            else
            {
                output = Convert.ToString(input[length / 2]);
            }
            return output;
        }
    }
}

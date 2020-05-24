using System;

namespace Problem_5._Messages
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            string message = "";
            for(int i=1;i<=num;i++)
            {
                int input = int.Parse(Console.ReadLine());
               
                if (input == 2)
                {
                    message+= "a";
                }
                if (input == 22)
                {
                    message += "b";
                }
                if (input == 222)
                {
                    message += "c";
                }
                if (input == 3)
                {
                    message += "d";
                }
                if (input == 33)
                {
                    message += "e";
                }
                if (input == 333)
                {
                    message += "f";
                }
                if (input == 4)
                {
                    message += "g";
                }
                if (input == 44)
                {
                    message += "h";
                }
                if (input == 444)
                {
                    message += "i";
                }
                if (input == 5)
                {
                    message += "j";
                }
                if (input == 55)
                {
                    message += "k";
                }
                if (input == 555)
                {
                    message += "l";
                }
                if (input == 6)
                {
                    message += "m";
                }
                if (input == 66)
                {
                    message += "n";
                }
                if (input == 666)
                {
                    message += "o";
                }
                if (input == 7)
                {
                    message += "p";
                }
                if (input == 77)
                {
                    message += "q";
                }
                if (input == 777)
                {
                    message += "r";
                }
                if (input == 7777)
                {
                    message += "s";
                }
                if (input == 8)
                {
                    message += "t";
                }
                if (input == 88)
                {
                    message += "u";
                }
                if (input == 888)
                {
                    message += "v";
                }
                if (input == 9)
                {
                    message += "w";
                }
                if (input == 99)
                {
                    message += "x";
                }
                if (input == 999)
                {
                    message += "y";
                }
                if (input == 9999)
                {
                    message += "z";
                }
                if (input == 0)
                {
                    message += " ";
                }
            }
            Console.WriteLine(message);
        }
    }
}

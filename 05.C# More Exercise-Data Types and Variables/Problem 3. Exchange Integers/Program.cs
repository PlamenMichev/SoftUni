using System;

namespace Problem_3._Exchange_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secNum = int.Parse(Console.ReadLine());
            Console.WriteLine($"Before: \na = {firstNum} \nb = {secNum}");
            int helpVar=0;

            helpVar = firstNum;
            firstNum = secNum;
            secNum = helpVar;
            Console.WriteLine($"After: \na = {firstNum} \nb = {secNum}");
        }
    }
}

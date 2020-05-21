using System;

namespace Personal_Titles
{
    class Program
    {
        static void Main(string[] args)
        {
            double age = double.Parse(Console.ReadLine());
            char sex = char.Parse(Console.ReadLine());
            if (sex == 'm')
            {
                if (age >= 16)
                {
                    Console.WriteLine("Mr.");
                }
                else Console.WriteLine("Master");
            }
            else
            {
                if(age>=16)
                {
                    Console.WriteLine("Ms.");
                }
                else
                {
                    Console.WriteLine("Miss");
                }
            }

        }
    }
}

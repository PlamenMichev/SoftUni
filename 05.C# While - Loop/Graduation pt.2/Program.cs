using System;

namespace Graduation
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            double mark;
            int i = 1;
            double sum = 0;
            int count = 0;
            while (i <= 12)
            {
                mark = double.Parse(Console.ReadLine());
                if (mark >= 4.00)
                {
                    sum = sum + mark;
                    i++;
                }
                else
                {
                    count++;
                    if(count==2)
                    {
                        Console.WriteLine($"{name} has been excluded at {i} grade");
                        break;
                    }
                }
            }
            if (count < 2) { Console.WriteLine($"{name} graduated. Average grade: {sum / 12:f2}"); }
        }
    }
}
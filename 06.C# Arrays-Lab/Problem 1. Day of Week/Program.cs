using System;

namespace Problem_1._Day_of_Week
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            string[] days = new string[7];
            days[0] = "Monday";
            days[1] = "Tuesday";
            days[2] = "Wednesday";
            days[3] = "Thursday";
            days[4] = "Friday";
            days[5] = "Saturday";
            days[6] = "Sunday";
            if(num<=0 || num>7)
            {
                Console.WriteLine("Invalid day!");
            }
            for (int i = 0; i < 7; i++)
            {
                if(num==i+1)
                {
                    Console.WriteLine(days[i]);
                    break;
                }
            }
        }
    }
}

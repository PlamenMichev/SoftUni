using System;
using System.Globalization;

namespace Days_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            string input1 = Console.ReadLine();
            DateTime date = DateTime.ParseExact(input, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            DateTime date1 = DateTime.ParseExact(input1, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            for (int i = 1; i <= num; i++)
            {
                if (i % 2 == 0)
                {
                    date = date.AddDays(1);
                }
                else date1 = date1.AddDays(1);
            }
            
            Console.WriteLine(date1.Day+date.Day);
        }
    }
}

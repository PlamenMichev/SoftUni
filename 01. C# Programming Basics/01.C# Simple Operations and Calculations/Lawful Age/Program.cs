using System;
using System.Globalization;

namespace Lawful_Age
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int month = int.Parse(input.Split('-')[1]);
            DateTime date = DateTime.ParseExact(input,"d-m-yyyy", CultureInfo.InvariantCulture);
            date = date.AddYears(18);
            date = date.AddMonths(month - 1);
            Console.WriteLine(date.ToString($"{date:dd-MM-yyyy}"));
        }
    }
}

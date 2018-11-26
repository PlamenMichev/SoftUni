using System;
using System.Globalization;

namespace Problem_1._Day_of_Week
{
    class Program
    {
        static void Main(string[] args)
        {
            string dateAsString = Console.ReadLine();
            DateTime date = DateTime.ParseExact(dateAsString, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            Console.WriteLine(date.DayOfWeek);
        }
    }
}

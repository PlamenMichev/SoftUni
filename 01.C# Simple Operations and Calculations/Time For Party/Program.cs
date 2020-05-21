using System;
using System.Globalization;

namespace Time_For_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            DateTime data = DateTime.ParseExact(input, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            DayOfWeek thisDay = data.DayOfWeek;
            if(thisDay.ToString()=="Saturday" || thisDay.ToString() == "Friday")
            {
                Console.WriteLine($"Party night! Today is: {thisDay.ToString()}");
            }
            else Console.WriteLine($"No party tonight! Today is: {thisDay.ToString()}");
        }
    }
}

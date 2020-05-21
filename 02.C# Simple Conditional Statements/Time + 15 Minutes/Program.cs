using System;

namespace Time___15_Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int hour = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());
            minutes = minutes + 15;
            if(minutes>59)
            {
                hour++;
                minutes = minutes - 60;
                if(hour>23)
                {
                    hour = hour - 24;
                }
            }
            if(minutes<10)
            {
                Console.WriteLine(hour+":0"+minutes);
            }
            else Console.WriteLine(hour+":"+minutes);
        }
    }
}

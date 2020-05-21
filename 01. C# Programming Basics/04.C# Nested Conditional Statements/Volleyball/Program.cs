using System;

namespace Volleyball
{
    class Program
    {
        static void Main(string[] args)
        {
            string year = Console.ReadLine();
            int holidays = int.Parse(Console.ReadLine());
            int weekendsInHisTown = int.Parse(Console.ReadLine());
            int weekendsInSofia = 48 - weekendsInHisTown;
            double games = weekendsInSofia * 0.75;
            games = games + weekendsInHisTown;
            games = games + (holidays * (2.0/3));
            if(year=="leap")
            {
                games = games + (0.15 * games);
                Console.WriteLine(Math.Floor(games));
            }
            else Console.WriteLine(Math.Floor(games));

        }
    }
}

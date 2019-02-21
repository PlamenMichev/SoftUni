using System;
using _05.DateModifier;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string firstDate = Console.ReadLine();
            string secDate = Console.ReadLine();

            var dateDifference = new DateModifier();

            double answer = dateDifference.CalculatesDifference(firstDate, secDate);
            Console.WriteLine(Math.Abs(answer));
        }
    }
}

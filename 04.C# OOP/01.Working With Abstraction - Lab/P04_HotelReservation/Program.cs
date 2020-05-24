using System;

namespace P04_HotelReservation
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var pricePerDay = decimal.Parse(input[0]);
            var numberOfDays = int.Parse(input[1]);
            Season season = (Season)Enum.Parse(typeof(Season), input[2]);
            var priceCalculator = new PriceCalculator();
            if (input.Length == 4)
            {
                Discount discount = (Discount)Enum.Parse(typeof(Discount), input[3]);
                Console.WriteLine($"{priceCalculator.Calculate(pricePerDay, numberOfDays, season, discount):f2}");
                return;
            }

            Console.WriteLine($"{priceCalculator.Calculate(pricePerDay, numberOfDays, season, Discount.None):f2}");
        }
    }
}

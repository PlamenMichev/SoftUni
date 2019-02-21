using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.SpeedRacing
{
    public class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < length; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = input[0];
                double fuelAmount = double.Parse(input[1]);
                double fuelConsumptionPerKilometer = double.Parse(input[2]);
                cars.Add(new Car(model, fuelAmount, fuelConsumptionPerKilometer));
            }

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }

                string[] tokens = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = tokens[1];
                int amountOfKm = int.Parse(tokens[2]);

                var currentCar = cars.FirstOrDefault(x => x.Model == model);

                if (currentCar.CanDriveDistance(amountOfKm))
                {
                    currentCar.FuelAmount -= (amountOfKm * currentCar.FuelConsumptionPerKilometer);
                    currentCar.Distance += (int)amountOfKm;
                }
                else
                {
                    Console.WriteLine($"Insufficient fuel for the drive");
                }
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.Distance}");
            }
        }
    }
}

using _02.VehicleExtentions.Models;
using System;
using System.Collections.Generic;

namespace _02.VehicleExtentions
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] carTokens = Console.ReadLine()
            .Split();
            double carFuel = double.Parse(carTokens[1]);
            double carConsuption = double.Parse(carTokens[2]);
            int carTankCapacity = int.Parse(carTokens[3]);

            string[] truckTokens = Console.ReadLine()
                .Split();
            double truckFuel = double.Parse(truckTokens[1]);
            double truckConsuption = double.Parse(truckTokens[2]);
            int trcukTankCapacity = int.Parse(truckTokens[3]);

            string[] busTokens = Console.ReadLine()
                .Split();
            double busFuel = double.Parse(busTokens[1]);
            double busConsuption = double.Parse(busTokens[2]);
            int busTankCapacity = int.Parse(busTokens[3]);

            Car car = new Car(carFuel, carConsuption, carTankCapacity);
            Truck truck = new Truck(truckFuel, truckConsuption, trcukTankCapacity);
            Bus bus = new Bus(busFuel, busConsuption, busTankCapacity);

            int length = int.Parse(Console.ReadLine());
            for (int i = 0; i < length; i++)
            {
                try
                {
                    string[] input = Console.ReadLine()
                    .Split();

                    string vehicle = input[1];
                    string action = input[0];
                    double quantity = double.Parse(input[2]);

                    if (vehicle == "Car")
                    {
                        if (action == "Drive")
                        {
                            Console.WriteLine($"{car.Drive(quantity)}");
                        }
                        else
                        {
                            car.Refuel(quantity);
                        }
                    }
                    else if (vehicle == "Truck")
                    {
                        if (action == "Drive")
                        {
                            Console.WriteLine($"{truck.Drive(quantity)}");
                        }
                        else
                        {
                            truck.Refuel(quantity);
                        }
                    }
                    else
                    {
                        if (action == "Drive")
                        {
                            Console.WriteLine($"{bus.Drive(quantity)}");
                        }
                        else if (action == "Refuel")
                        {
                            bus.Refuel(quantity);
                        }
                        else
                        {
                            Console.WriteLine($"{bus.DriveEmpty(quantity)}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }
    }
}

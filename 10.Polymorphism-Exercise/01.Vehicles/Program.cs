using System;

namespace _01.Vehicles
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] carTokens = Console.ReadLine()
                .Split();
            double carFuel = double.Parse(carTokens[1]);
            double carConsuption = double.Parse(carTokens[2]);

            string[] truckTokens = Console.ReadLine()
                .Split();
            double truckFuel = double.Parse(truckTokens[1]);
            double truckConsuption = double.Parse(truckTokens[2]);

            Vehicle car = new Car(carFuel, carConsuption);
            Vehicle truck = new Truck(truckFuel, truckConsuption);

            int length = int.Parse(Console.ReadLine());
            for (int i = 0; i < length; i++)
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
                else
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
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
        }
    }
}

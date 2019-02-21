using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.RawData
{
    public class StartUp
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
                int engineSpeed = int.Parse(input[1]);
                int enginePower = int.Parse(input[2]);
                int cargoWeight = int.Parse(input[3]);
                string cargoType = input[4];
                Tire[] currentTires = new Tire[4]
                {
                    new Tire(double.Parse(input[5]), int.Parse(input[6])),
                    new Tire(double.Parse(input[7]), int.Parse(input[8])),
                    new Tire(double.Parse(input[9]), int.Parse(input[10])),
                    new Tire(double.Parse(input[11]), int.Parse(input[12])),
                };

                var currentEngine = new Engine(engineSpeed, enginePower);
                var currentCargo = new Cargo(cargoWeight, cargoType);

                var currentCar = new Car(model, currentEngine, currentCargo, currentTires);
                cars.Add(currentCar);
            }

            string filter = Console.ReadLine();
            if (filter == "fragile")
            {
                var result = cars
                    .Where(x => x.Cargo.CargoType == "fragile")
                    .ToList();

                foreach (var car in result)
                {
                    bool isValid = false;
                    foreach (var tire in car.Tires)
                    {
                        if (tire.Pressure < 1)
                        {
                            isValid = true;
                        }
                    }

                    if (isValid)
                    {
                        Console.WriteLine(car.Model);
                    }
                }
            }
            else
            {
                if (filter == "flamable")
                {
                    var result = cars
                        .Where(x => x.Cargo.CargoType == "flamable")
                        .Where(x => x.Engine.Power > 250)
                        .ToList();

                    foreach (var car in result)
                    {
                        Console.WriteLine(car.Model);
                    }
                }
            }

        }
    }
}

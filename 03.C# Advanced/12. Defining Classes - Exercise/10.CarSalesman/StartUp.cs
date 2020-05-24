using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace _10.CarSalesman
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int enginesLength = int.Parse(Console.ReadLine());
            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();

            for (int i = 0; i < enginesLength; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = input[0];
                int power = int.Parse(input[1]);

                var currentEngine = new Engine();

                if (input.Length == 4)
                {
                    int displacement = int.Parse(input[2]);
                    string efficiency = input[3];
                    currentEngine = new Engine(model, power, displacement, efficiency);
                }
                else
                {
                    if (input.Length == 3)
                    {
                        bool isDisplacement =
                            int.TryParse(input[2], out int displacement);
                        if (isDisplacement)
                        {
                            currentEngine = new Engine(model, power, displacement);
                        }
                        else
                        {
                            currentEngine = new Engine(model, power, input[2]);
                        }
                    }
                    else
                    {
                        if (input.Length == 2)
                        {
                            currentEngine = new Engine(model, power);
                        }
                    }
                }

                engines.Add(currentEngine);
            }

            int carLength = int.Parse(Console.ReadLine());

            for (int i = 0; i < carLength; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = input[0];
                string engine = input[1];
                var currentCar = new Car();
                Engine cuurentEngine = engines.FirstOrDefault(x => x.Model == engine);

                if (input.Length == 4)
                {
                    int weight = int.Parse(input[2]);
                    string color = input[3];

                    currentCar = new Car(model, cuurentEngine, weight, color);
                }
                else
                {
                    if (input.Length == 3)
                    {
                        bool isWeight =
                            double.TryParse(input[2], out double weight);
                        if (isWeight)
                        {
                            currentCar = new Car(model, cuurentEngine, weight);
                        }
                        else
                        {
                            currentCar = new Car(model, cuurentEngine, input[2]);
                        }
                        
                    }
                    else
                    {
                        if (input.Length == 2)
                        {
                            currentCar = new Car(model, cuurentEngine);
                        }
                    }
                }
                cars.Add(currentCar);
            }

            Console.WriteLine(string.Join(Environment.NewLine, cars));
        }
    }
}

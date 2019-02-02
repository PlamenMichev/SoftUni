using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_6._Auto_Repair_and_Service
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputCars = Console.ReadLine().Split();
            Queue<string> cars = new Queue<string>(inputCars);
            Stack<string> repairedCars = new Stack<string>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    if (cars.Any())
                    {
                        Console.WriteLine($"Vehicles for service: {string.Join(", ", cars.ToList())}");
                    }
                    
                    Stack<string> repairedCarsInStack = new Stack<string>(repairedCars);
                    if ((repairedCarsInStack.Any()))
                    {
                        Console.WriteLine($"Served vehicles: {string.Join(", ", repairedCars.ToList())}");
                    }                              
                    break;
                }

                string[] tokens = input.Split();
                string command = tokens[0];
                if (command == "Service" && cars.Any())
                {
                    string temp = cars.Dequeue();
                    repairedCars.Push(temp);
                    Console.WriteLine($"Vehicle {temp} got served.");
                }

                if (command.Contains("-"))
                {
                    string[] carCommand = command.Split("-");
                    string carName = carCommand[1];
                    if (cars.Contains(carName))
                    {
                        Console.WriteLine("Still waiting for service.");
                    }
                    else
                    {
                        Console.WriteLine("Served.");
                    }
                }

                if (command == "History")
                {
                    Console.WriteLine($"{string.Join(", ", repairedCars.ToList())}");
                }
            }
        }
    }
}

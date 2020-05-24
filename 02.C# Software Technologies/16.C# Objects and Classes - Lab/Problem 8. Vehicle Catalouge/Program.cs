using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_8._Vehicle_Catalouge
{
    class Program
    {
        class Truck
        {
            public string Brand { get; set; }
            public string Model { get; set; }
            public int Weight { get; set; }
        }

        class Car
        {
            public string Brand { get; set; }
            public string Model { get; set; }
            public int HorsePower { get; set; }
        }

        class Catalogue
        {
            public Catalogue()
            {
                Cars = new List<Car>();
                Trucks = new List<Truck>();
            }

            public List<Truck> Trucks { get; set; }
            public List<Car> Cars { get; set; }
        }
        static void Main(string[] args)
        {
            Catalogue catalogue = new Catalogue();
            while (true)
            {
                
                string input = Console.ReadLine();
                if (input == "end")
                {
                    break;
                }

                string[] tokens = input.Split("/");
                string type = tokens[0];
                string brand = tokens[1];
                string model = tokens[2];
                if (type == "Car")
                {
                    int horsePower = int.Parse(tokens[3]);
                    Car car = new Car
                    {
                        Brand = brand,
                        Model = model,
                        HorsePower = horsePower
                    };
                    catalogue.Cars.Add(car);
                }
                else
                {
                    int weight = int.Parse(tokens[3]);
                    Truck truck = new Truck()
                    {
                        Brand = brand,
                        Model = model,
                        Weight = weight
                    };
                    catalogue.Trucks.Add(truck);
                }
                
            }

            Console.WriteLine("Cars:");
            foreach (var car in catalogue.Cars.OrderBy(x=>x.Brand))
            {
                Console.WriteLine($"{car.Brand}: {car.Model} - {car.HorsePower}hp");
            }

            Console.WriteLine("Trucks:");
            foreach (var truck in catalogue.Trucks.OrderBy(x=>x.Brand))
            {
                Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weight}kg");
            }
        }
    }
}

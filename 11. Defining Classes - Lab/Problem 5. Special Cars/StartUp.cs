using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarManufacturer
{
    public class Engine
    {
        private int horsePower;
        private double cubicCapacity;

        public Engine(int horsePower, double cubicCapacity)
        {
            this.HorsePower = horsePower;
            this.CubicCapacity = cubicCapacity;
        }

        public int HorsePower
        {
            get => this.horsePower;
            set => this.horsePower = value;
        }

        public double CubicCapacity
        {
            get => this.cubicCapacity;
            set => this.cubicCapacity = value;
        }
    }

    public class Car
    {
        private string make;
        private string model;
        private int year;
        private double fuelQuantity;
        private double fuelConsumption;
        private Engine engine;
        private Tire[] tires;

        public Car()
        {
            this.Make = "VW";
            this.Model = "Golf";
            this.Year = 2025;
            this.FuelQuantity = 200;
            this.FuelConsumption = 10;
        }

        public Car(string make, string model, int year) : this()
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
        }

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption)
            : this(make, model, year)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption, Engine engine, Tire[] tires)
            : this(make, model, year, fuelQuantity, fuelConsumption)
        {
            this.Engine = engine;
            this.Tires = tires;
        }

        public Engine Engine
        {
            get => this.engine;
            set => this.engine = value;
        }

        public Tire[] Tires
        {
            get => this.tires;
            set => this.tires = value;
        }

        public string Make
        {
            get { return this.make; }
            set { this.make = value; }
        }

        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }

        public int Year
        {
            get { return this.year; }
            set { this.year = value; }
        }

        public double FuelQuantity
        {
            get { return this.fuelQuantity; }
            set { this.fuelQuantity = value; }
        }

        public double FuelConsumption
        {
            get { return this.fuelConsumption; }
            set { this.fuelConsumption = value; }
        }



        public void Drive(double distance)
        {
            bool canContinue = this.FuelQuantity - (distance * this.FuelConsumption) / 100 >= 0;
            if (canContinue)
            {
                this.FuelQuantity -= (distance * this.FuelConsumption) / 100;
            }

            else
            {
                Console.WriteLine($"Not enough fuel to perform this trip!");
            }
        }

        public string WhoAmI()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Make: {this.Make}");
            sb.AppendLine($"Model: {this.Model}");
            sb.AppendLine($"Year: {this.Year}");
            sb.Append($"Fuel: {this.FuelQuantity:F2}L");
            return sb.ToString();
        }
    }
    public class Tire
    {
        private int year;
        private double pressure;

        public Tire(int year, double pressure)
        {
            this.Year = year;
            this.Pressure = pressure;
        }


        public int Year
        {
            get => this.year;
            set => this.year = value;
        }

        public double Pressure
        {
            get => this.pressure;
            set => this.pressure = value;
        }
    }
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Tire[]> tires = new List<Tire[]>();
            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();
            List<Car> specialCars = new List<Car>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "No more tires")
                {
                    break;
                }

                string[] tokens = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var currentTires = new Tire[4]
                {
                    new Tire(int.Parse(tokens[0]), double.Parse(tokens[1])), 
                    new Tire(int.Parse(tokens[2]), double.Parse(tokens[3])),
                    new Tire(int.Parse(tokens[4]), double.Parse(tokens[5])),
                    new Tire(int.Parse(tokens[6]), double.Parse(tokens[7])),
                };

                tires.Add(currentTires);
            }

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Engines done")
                {
                    break;
                }

                string[] tokens = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var currentEngine = new Engine(int.Parse(tokens[0]), double.Parse(tokens[1]));
                engines.Add(currentEngine);
            }

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Show special")
                {
                    break;
                }

                string[] tokens = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string make = tokens[0];
                string model = tokens[1];
                int year = int.Parse(tokens[2]);
                double fuelQuantity = double.Parse(tokens[3]);
                double fuelConsumption = double.Parse(tokens[4]);
                int engineIndex = int.Parse(tokens[5]);
                int tiresIndex = int.Parse(tokens[6]);

                var currentCar = new Car(make, model, year, fuelQuantity, fuelConsumption, engines[engineIndex], tires[tiresIndex]);

                bool isSpecial = IsSpecial(currentCar);

                if (isSpecial)
                {
                    currentCar.Drive(20);
                    specialCars.Add(currentCar);
                }
            }

            foreach (var car in specialCars)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"Make: {car.Make}");
                sb.AppendLine($"Model: {car.Model}");
                sb.AppendLine($"Year: {car.Year}");
                sb.AppendLine($"HorsePowers: {car.Engine.HorsePower}");
                sb.Append($"FuelQuantity: {car.FuelQuantity}");
                Console.WriteLine(sb.ToString());               
            }
        }

        public static bool IsSpecial(Car car)
        {
            bool isSpecial = false;

            if (car.Year >= 2017 && car.Engine.HorsePower >= 330 && car.Tires.Select(x => x.Pressure).Sum() >= 9 
                && car.Tires.Select(x => x.Pressure).Sum() <= 10)
            {
                isSpecial = true;
            }

            return isSpecial;
        }
    }
}

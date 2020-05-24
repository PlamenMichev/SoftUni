using System;

namespace _02.VehicleExtentions
{
    public abstract class Vehicle
    {
        private double fuelQuantity;

        protected Vehicle(double fuelQuantity, double fuelConsuption, int tankCapacity)
        {
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsuption = fuelConsuption;
        }

        public int TankCapacity { get; private set; }

        public double FuelQuantity
        {
            get => this.fuelQuantity;
            protected set
            {
                if (value > this.TankCapacity)
                {
                    this.fuelQuantity = 0;
                }
                else
                {
                    this.fuelQuantity = value;
                }
            }
        }

        public double FuelConsuption { get; protected set; }

        public string Drive(double distance)
        {
            string vehicleName = this.GetType().Name;
            double needeFuel = this.FuelConsuption * distance;

            if (this.FuelQuantity >= needeFuel)
            {
                this.FuelQuantity -= needeFuel;
                return $"{vehicleName} travelled {distance} km";
            }

            return $"{vehicleName} needs refueling";
        }

        public virtual void Refuel(double fuelToAdd)
        {
            if (fuelToAdd <= 0)
            {
                throw new ArgumentException($"Fuel must be a positive number");
            }

            double totalFuel = this.fuelQuantity + fuelToAdd;

            if (totalFuel > this.TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {fuelToAdd} fuel in the tank");
            }

            this.FuelQuantity += fuelToAdd;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}

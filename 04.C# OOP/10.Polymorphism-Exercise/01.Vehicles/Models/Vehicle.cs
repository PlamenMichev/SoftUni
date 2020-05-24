using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles
{
    public abstract class Vehicle
    {
        protected Vehicle(double fuelQuantity, double fuelConsuption)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsuption = fuelConsuption;
        }

        public double FuelQuantity { get; protected set; }

        public double FuelConsuption { get; private set; }

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

        public virtual void Refuel(double fuel)
        {
            this.FuelQuantity += fuel;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}

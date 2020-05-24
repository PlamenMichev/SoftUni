using System;
using System.Collections.Generic;
using System.Text;

namespace _07.SpeedRacing
{
    public class Car
    {
        public string Model { get; set; }
        
        public double FuelAmount { get; set; }

        public double FuelConsumptionPerKilometer { get; set; }

        public int Distance { get; set; }

        public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
        }

        public bool CanDriveDistance(int distance)
        {
            double canDrive = this.FuelAmount - distance * this.FuelConsumptionPerKilometer;

            if (canDrive >= 0)
            {
                return true;
            }

            else
            {
                return false;
            }
            
        }
    }
}

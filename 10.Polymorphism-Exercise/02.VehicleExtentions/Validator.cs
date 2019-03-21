using System;
using System.Collections.Generic;
using System.Text;

namespace _02.VehicleExtentions
{
    public static class Validator
    {
        public static void ValidateFuel(double fuel)
        {
            if (fuel <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }
        }
    }
}

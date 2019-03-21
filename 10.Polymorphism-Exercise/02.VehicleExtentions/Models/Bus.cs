namespace _02.VehicleExtentions.Models
{
    public class Bus : Vehicle
    {
        private const double airconditionarConsumption = 1.4;

        public Bus(double fuelQuantity, double fuelConsuption, int tankCapacity) 
            : base(fuelQuantity, fuelConsuption + airconditionarConsumption, tankCapacity)
        {
        }

        public string DriveEmpty(double distance)
        {
            this.FuelConsuption -= airconditionarConsumption;
            return base.Drive(distance);
        }
    }
}

namespace _02.VehicleExtentions
{
    public class Truck : Vehicle
    {
        private const double airConditionerConsumption = 1.6;
        private const double wastedFuel = 0.05;

        public Truck(double fuelQuantity, double fuelConsuption, int tankCapacity) 
            : base(fuelQuantity, fuelConsuption + airConditionerConsumption, tankCapacity)
        {
        }

        public override void Refuel(double fuel)
        {
            base.Refuel(fuel);
            this.FuelQuantity -= fuel * wastedFuel;
        }
    }
}

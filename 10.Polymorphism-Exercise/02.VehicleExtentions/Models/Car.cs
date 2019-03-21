namespace _02.VehicleExtentions
{
    public class Car : Vehicle
    {
        private const double airConditionerConsumption = 0.9;
        
        public Car(double fuelQuantity, double fuelConsuption, int tankCapacity) 
            : base(fuelQuantity, fuelConsuption + airConditionerConsumption, tankCapacity)
        {
        }
    }
}

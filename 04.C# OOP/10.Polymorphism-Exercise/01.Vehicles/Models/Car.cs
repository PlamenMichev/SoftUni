namespace _01.Vehicles
{
    public class Car : Vehicle
    {
        private const double airConditionerConsumption = 0.9;

        public Car(double fuelQuantity, double fuelConsuption) 
            : base(fuelQuantity, fuelConsuption + airConditionerConsumption)
        {
        }
    }
}

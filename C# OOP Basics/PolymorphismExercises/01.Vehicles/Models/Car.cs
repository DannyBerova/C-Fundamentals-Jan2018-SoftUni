public class Car : Vehicle
{
    public Car(double fuelQuantity, double fuelConsumptionPerKm) 
        : base(fuelQuantity, fuelConsumptionPerKm)
    {
    }

    public override double FuelConsumptionPerKm
    {
        get => base.FuelConsumptionPerKm + 0.9; 
    }
}


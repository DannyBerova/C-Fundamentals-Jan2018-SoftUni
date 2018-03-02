using System;

public class Car : Vehicle
{
    public Car(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity)
        : base(fuelQuantity, fuelConsumptionPerKm, tankCapacity)
    {
        this.FuelConsumptionPerKm += carACExtraConsumption;
    }
}


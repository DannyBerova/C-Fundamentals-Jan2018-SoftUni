using System;

public class Truck : Vehicle
{
    public Truck(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity)
        : base(fuelQuantity, fuelConsumptionPerKm, tankCapacity)
    {
        this.FuelConsumptionPerKm += truckACExtraConsumption;
    }

    public override void Refuel(double amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException(FuelAmountError);
        }

        if (this.FuelQuantity + amount * FuelLossRatio > this.TankCapacity)
        {
            throw new ArgumentException(string.Format(ExessFuelErrorMessage, amount));
        }
        this.FuelQuantity += amount * FuelLossRatio;
    }
}
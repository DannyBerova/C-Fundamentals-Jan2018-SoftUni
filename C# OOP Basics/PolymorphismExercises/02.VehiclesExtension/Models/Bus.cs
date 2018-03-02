using System;

public class Bus : Vehicle
{
    public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
    : base(fuelQuantity, fuelConsumption, tankCapacity)
    {
    }

    public override void Drive(double distance)
    {
        var fuelNeeded = distance * (this.FuelConsumptionPerKm + busACExtraConsumption);

        if (fuelNeeded > this.FuelQuantity)
        {
            throw new ArgumentException(string.Format(InsufficientFuelErrorMessage, this.GetType().Name));
        }

        this.FuelQuantity -= fuelNeeded;
    }

    public void DriveEmpty(double distance)
    {
        base.Drive(distance);
    }
}

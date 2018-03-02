using System;

public abstract class Vehicle
{
    public const string InsufficientFuelErrorMessage = "{0} needs refueling";
    public const string FuelAmountError = "Fuel must be a positive number";
    public const string ExessFuelErrorMessage = "Cannot fit {0} fuel in the tank";
    public const double carACExtraConsumption = 0.9;
    public const double truckACExtraConsumption = 1.6;
    public const double busACExtraConsumption = 1.4;
    public const double FuelLossRatio = 0.95;

    private double fuelQuantity;
    private double fuelConsumptionPerKm;
    private double tankCapacity;

    protected Vehicle(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity)
    {
        this.TankCapacity = tankCapacity;
        this.FuelQuantity = fuelQuantity;
        this.FuelConsumptionPerKm = fuelConsumptionPerKm;
    }

    public double FuelQuantity
    {
        get { return this.fuelQuantity; }
        protected set
        {
            if (value <= 0)
            {
                throw new ArgumentException(FuelAmountError);
            }

            if (value > this.TankCapacity)
            {
                this.fuelQuantity = 0;
            }
            else
            {
                this.fuelQuantity = value;
            }
        }
    }

    public virtual double FuelConsumptionPerKm
    {
        get { return this.fuelConsumptionPerKm; }
        set { this.fuelConsumptionPerKm = value; }
    }

    public double TankCapacity
    {
        get { return this.tankCapacity; }
        set { this.tankCapacity = value; }
    }

    public virtual void Drive(double distance)
    {
        var fuelNeeded = distance * (this.FuelConsumptionPerKm);

        if (fuelNeeded > this.FuelQuantity)
        {
            throw new ArgumentException(string.Format(InsufficientFuelErrorMessage, this.GetType().Name));
        }

        this.FuelQuantity -= fuelNeeded;
    }

    public virtual void Refuel(double amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException(FuelAmountError);
        }

        if (this.fuelQuantity + amount > this.tankCapacity)
        {
            throw new ArgumentException(string.Format(ExessFuelErrorMessage, amount));
        }
        else
        {
            this.FuelQuantity += amount;
        }
    }

    public override string ToString()
    {
        return $"{this.GetType().Name}: {this.FuelQuantity:F2}";
    }
}
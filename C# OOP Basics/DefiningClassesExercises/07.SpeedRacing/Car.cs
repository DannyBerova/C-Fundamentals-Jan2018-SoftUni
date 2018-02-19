using System;

public class Car
{
    // Model, fuel amount, fuel consumption for 1 kilometer and distance traveled
    public string Model { get; set; }
    public double FuelAmount { get; set; }
    public double Consumption { get; set; }
    public double Distance { get; set; }

    public Car(string model, double fuelAmount, double consumption)
    {
        this.Model = model;
        this.FuelAmount = fuelAmount;
        this.Consumption = consumption;
        this.Distance = 0;
    }

    public bool Drive(double distance)
    {
        double fuelNeeded = distance * this.Consumption;
        if (this.FuelAmount < fuelNeeded)
        {
            return false;
        }
        this.FuelAmount -= fuelNeeded;
        this.Distance += distance;
        return true;
    }
}


using System;
using System.Collections.Generic;
using System.Linq;

public class PerformanceCar : Car
{
    public PerformanceCar(string brand, string model, int yearOfProduction, int horsepower, int acceleration, int suspension, int durability)
        : base(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability)
    {
        this.AddOns = new List<string>();
        this.Horsepower += horsepower * 50 / 100;
        this.Suspension -= suspension * 25 / 100;
    }

    public List<string> AddOns { get; }

    public override string ToString()
    {
        var sb = base.ToString();

        if (this.AddOns.Any())
        {
            sb += $"Add-ons: {string.Join(", ", this.AddOns)}";
        }
        else
        {
            sb += $"Add-ons: None";
        }

        return sb;
    }
}

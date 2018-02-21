using System;
using System.Collections.Generic;

public class Topping
{
    private string toppingType;
    private double weight;

    public Topping(string toppingType, double weight)
    {
        this.ToppingType = toppingType;
        this.Weight = weight;
    }

    public string ToppingType
    {
        get
        {
            return this.toppingType;
        }
        private set
        {
            if (value != "meat" && value != "veggies" && value != "cheese" && value != "sauce")
            {
                var valueName = value[0].ToString().ToUpper() + value.Substring(1);
                throw new Exception($"Cannot place {valueName} on top of your pizza.");
            }

            this.toppingType = value;
        }
    }

    public double Weight
    {
        get
        {
            return this.weight;
        }
        private set
        {
            if (value < 1 || value > 50)
            {
                var valueName = this.toppingType[0].ToString().ToUpper() + this.toppingType.Substring(1);
                throw new Exception($"{valueName} weight should be in the range [1..50].");
            }

            this.weight = value;
        }
    }

    public double ToppingCalories()
    {
        return 2 * Weight * ToppingTypeModifier();
    }

    private double ToppingTypeModifier()
    {
        if (this.ToppingType == "meat")
        {
            return 1.2;
        }
        else if (this.ToppingType == "veggies")
        {
            return 0.8;
        }
        else if (this.ToppingType == "cheese")
        {
            return 1.1;
        }
        else
        {
            return 0.9;
        }
    }
}


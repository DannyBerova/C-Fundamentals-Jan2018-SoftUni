using System;

public class ShowCar : Car
{
    public ShowCar(string brand, string model, int yearOfProduction, int horsepower, int acceleration, int suspension, int durability)
        : base(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability)
    {
        this.Stars = 0;
    }

    public int Stars { get; set; }

    public override string ToString()
    {
        return $"{base.ToString()}{this.Stars} *";
    }
}

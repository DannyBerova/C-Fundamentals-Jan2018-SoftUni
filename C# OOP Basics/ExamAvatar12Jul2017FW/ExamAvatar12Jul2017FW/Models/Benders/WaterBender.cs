public class WaterBender : Bender
{
    private double waterClarity;

    
    public WaterBender(string name, int power, double waterClarity) 
        : base(name, power)
    {
        this.WaterClarity = waterClarity;
    }

    public double WaterClarity
    {
        get { return waterClarity; }
        private set { waterClarity = value; }
    }

    public override double GetPower()
    {
        return this.waterClarity * this.Power;
    }

    public override string ToString()
    {
        return $"Water {base.ToString()}, Water Clarity: {this.waterClarity:F2}";
    }
}


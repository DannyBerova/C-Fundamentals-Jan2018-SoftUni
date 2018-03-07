public class FireBender : Bender
{
    private double heatAggression;


    public FireBender(string name, int power, double heatAggression) 
        : base(name, power)
    {
        this.HeatAggression = heatAggression;
    }

    public double HeatAggression
    {
        get { return heatAggression; }
        private set { heatAggression = value; }
    }

    public override double GetPower()
    {
        return this.heatAggression * this.Power;
    }

    public override string ToString()
    {
        return $"Fire {base.ToString()}, Heat Aggression: {this.heatAggression:F2}";
    }
}


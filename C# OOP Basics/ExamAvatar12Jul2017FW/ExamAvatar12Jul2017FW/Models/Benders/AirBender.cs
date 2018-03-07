public class AirBender : Bender
{
    private double aerialIntegrity;

    public AirBender(string name, int power, double aerialIntegrity) 
        : base(name, power)
    {
        this.AerialIntegrity = aerialIntegrity;
    }

    public double AerialIntegrity
    {
        get { return aerialIntegrity; }
        private set { aerialIntegrity = value; }
    }

    public override double GetPower()
    {
        return this.aerialIntegrity * this.Power;
    }

    public override string ToString()
    {
        return $"Air {base.ToString()}, Aerial Integrity: {this.aerialIntegrity:F2}";
    }
}


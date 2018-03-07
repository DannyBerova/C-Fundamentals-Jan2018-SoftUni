public class EarthBender : Bender
{
    private double groundSaturation;


    public EarthBender(string name, int power, double groundSaturation) 
        : base(name, power)
    {
        this.GroundSaturation = groundSaturation;
    }

    public double GroundSaturation
    {
        get { return groundSaturation; }
        private set { groundSaturation = value; }
    }

    public override double GetPower()
    {
        return this.groundSaturation * this.Power;
    }

    public override string ToString()
    {
        return $"Earth {base.ToString()}, Ground Saturation: {this.groundSaturation:F2}";
    }
}


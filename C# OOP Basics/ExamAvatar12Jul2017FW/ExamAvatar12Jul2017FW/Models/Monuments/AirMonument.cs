public class AirMonument : Monument
{
    private int airAffinity;

    public AirMonument(string name, int airAffinity) 
        : base(name)
    {
        this.AirAffinity = airAffinity;
    }

    public int AirAffinity
    {
        get { return airAffinity; }
        set { airAffinity = value; }
    }

    public override double GetAffinity()
    {
        return this.airAffinity;
    }

    public override string ToString()
    {
        return $"Air {base.ToString()}, Air Affinity: {this.airAffinity}";
    }
}

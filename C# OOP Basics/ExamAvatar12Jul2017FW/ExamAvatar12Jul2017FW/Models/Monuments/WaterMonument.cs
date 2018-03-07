public class WaterMonument : Monument
{
    private int waterAffinity;

    public WaterMonument(string name, int waterAffinity)
        : base(name)
    {
        this.WaterAffinity = waterAffinity;
    }

    public int WaterAffinity
    {
        get { return waterAffinity; }
        set { waterAffinity = value; }
    }

    public override double GetAffinity()
    {
        return this.waterAffinity;
    }

    public override string ToString()
    {
        return $"Water {base.ToString()}, Water Affinity: {this.waterAffinity}";
    }
}


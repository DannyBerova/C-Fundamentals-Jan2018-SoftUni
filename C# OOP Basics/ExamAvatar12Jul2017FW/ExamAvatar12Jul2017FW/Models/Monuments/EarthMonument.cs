public class EarthMonument : Monument
{
    private int earthAffinity;

    public EarthMonument(string name, int earthAffinity)
        : base(name)
    {
        this.EarthAffinity = earthAffinity;
    }

    public int EarthAffinity
    {
        get { return earthAffinity; }
        set { earthAffinity = value; }
    }

    public override double GetAffinity()
    {
        return this.earthAffinity;
    }

    public override string ToString()
    {
        return $"Earth {base.ToString()}, Earth Affinity: {this.earthAffinity}";
    }
}

public class FireMonument : Monument
{
    private int fireAffinity;

    public FireMonument(string name, int fireAffinity)
        : base(name)
    {
        this.FireAffinity = fireAffinity;
    }

    public int FireAffinity
    {
        get { return fireAffinity; }
        set { fireAffinity = value; }
    }

    public override double GetAffinity()
    {
        return this.fireAffinity;
    }

    public override string ToString()
    {
        return $"Fire {base.ToString()}, Fire Affinity: {this.fireAffinity}";
    }
}
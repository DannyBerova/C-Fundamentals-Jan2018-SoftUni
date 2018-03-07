public abstract class Bender
{
    private string name;
    private int power;

    protected Bender(string name, int power)
    {
        this.Name = name;
        this.Power = power;
    }

    public int Power
    {
        get { return power; }
        protected set { power = value; }
    }

    public string Name
    {
        get { return name; }
        protected set { name = value; }
    }

    public abstract double GetPower();

    public override string ToString()
    {
        return $"Bender: { this.Name}, Power: { this.Power}";
    }
}



public class Power : Hardware
{
    public Power(string name, int maxCapacity, int maxMemory) 
        : base(name, maxCapacity, maxMemory)
    {
        this.MaxCapacity -= (base.MaxCapacity * 75)/100;
        this.MaxMemory += (base.MaxMemory * 75) / 100;
    }

    public override string Type => "Power";
}


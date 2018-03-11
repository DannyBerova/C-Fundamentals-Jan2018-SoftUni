public class Heavy : Hardware
{
    public Heavy(string name, int maxCapacity, int maxMemory) 
        : base(name, maxCapacity, maxMemory)
    {
        this.MaxCapacity += base.MaxCapacity;
        this.MaxMemory -= (base.MaxMemory * 25) / 100;
    }

    public override string Type => "Heavy";
}



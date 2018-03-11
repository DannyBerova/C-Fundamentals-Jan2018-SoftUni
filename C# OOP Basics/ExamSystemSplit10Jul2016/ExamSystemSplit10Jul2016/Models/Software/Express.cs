public class Express : Software
{
    public Express(string name, int capacityConsumption, int memoryConsumption) 
        : base(name, capacityConsumption, memoryConsumption)
    {
        this.MemoryConsumption += base.MemoryConsumption;
    }

    public override string Type => "Express";
}


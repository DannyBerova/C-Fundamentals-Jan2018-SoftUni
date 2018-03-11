public class Light : Software
{
    public Light(string name, int capacityConsumption, int memoryConsumption) 
        : base(name, capacityConsumption, memoryConsumption)
    {
        this.CapacityConsumption += (base.CapacityConsumption * 50) / 100;
        this.MemoryConsumption -= (base.MemoryConsumption * 50) / 100;
    }

    public override string Type => "Light";
}


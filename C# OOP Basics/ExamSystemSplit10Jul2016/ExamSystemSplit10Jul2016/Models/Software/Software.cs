public abstract class Software : Component
{
    private int capacityConsumption;
    private int memoryConsumption;

    protected Software(string name, int capacityConsumption, int memoryConsumption) 
        : base(name)
    {
        this.CapacityConsumption = capacityConsumption;
        this.MemoryConsumption = memoryConsumption;
    }

    public int MemoryConsumption
    {
        get { return memoryConsumption; }
        protected set { memoryConsumption = value; }
    }

    public int CapacityConsumption
    {
        get { return capacityConsumption; }
        protected set { capacityConsumption = value; }
    }

    public override string ToString()
    {
        return this.Name;
    }

}


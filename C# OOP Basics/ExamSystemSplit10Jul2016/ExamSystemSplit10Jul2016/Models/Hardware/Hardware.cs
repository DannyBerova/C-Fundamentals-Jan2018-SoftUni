using System.Collections.Generic;
using System.Linq;

public abstract class Hardware : Component
{
    private int maxCapacity;
    private int maxMemory;
    private ICollection<Software> softwares;

    protected Hardware(string name, int maxCapacity, int maxMemory) 
        : base(name)
    {
        this.MaxCapacity = maxCapacity;
        this.MaxMemory = maxMemory;
        this.Softwares = new HashSet<Software>();
    }

    public ICollection<Software> Softwares
    {
        get { return softwares; }
        protected set { softwares = value; }
    }

    public int MaxMemory
    {
        get { return maxMemory; }
        protected set { maxMemory = value; }
    }

    public int MaxCapacity
    {
        get { return maxCapacity; }
        protected set { maxCapacity = value; }
    }

    public int OperationalMemoryInUse()
    {
       return this.Softwares.Sum(s => s.MemoryConsumption);
    }

    public int CapacityTaken()
    {
        return this.Softwares.Sum(s => s.CapacityConsumption);
    }


}


using System;

public class InfinityHarvester : Harvester
{
    private const int OreOutputDivider = 10;
    private const int InitialDurability = 1000;

    private double durability;

    public InfinityHarvester(int id, double oreOutput, double energyRequirement) 
        : base(id, oreOutput / OreOutputDivider, energyRequirement) { }

    public override double Durability
    {
        get => this.durability;
        protected set => this.durability = Math.Max(0, value);
    }

    public override void Broke()
    {
        this.Durability = InitialDurability;
    }
}
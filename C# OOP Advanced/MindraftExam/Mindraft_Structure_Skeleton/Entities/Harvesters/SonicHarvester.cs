public class SonicHarvester : Harvester
{
    private const int EnergyDivider = 2;
    private const int DurabilityLoss = 300;

    public SonicHarvester(int id, double oreOutput, double energyRequirement) 
        : base(id, oreOutput, energyRequirement / EnergyDivider)
    {
        this.Durability -= DurabilityLoss;
}
}
public class HammerHarvester : Harvester
{
    private const int EnergieMultiplier = 2;
    private const int OreOutputMultiplier = 4;

    public HammerHarvester(int id, double oreOutput, double energyRequirement)
        : base(id, oreOutput * OreOutputMultiplier, energyRequirement * EnergieMultiplier)
    {
    }
}
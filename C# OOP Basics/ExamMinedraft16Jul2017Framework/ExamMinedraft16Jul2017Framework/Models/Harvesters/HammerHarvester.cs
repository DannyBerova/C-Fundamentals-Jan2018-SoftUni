using System.Text;

public class HammerHarvester : Harvester
{
    private const int oreOutputMultiplier = 2;
    public HammerHarvester(string id, double oreOutput, double energyRequierment) 
        : base(id, oreOutput, energyRequierment)
    {
        this.OreOutput += this.OreOutput * oreOutputMultiplier;
        this.EnergyRequirement += this.EnergyRequirement;
    }

    public override string ToString()
    {
        //{type} Harvester – {id}
        //Ore Output: {oreOutput}
        //Energy Requirement: {energyRequired}

        return $"Hammer {base.ToString().Trim()}";

    }
}


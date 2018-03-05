using System;
using System.Text;

public abstract class Harvester : Miner
{
    private const string ERROR_MESSAGE = "Harvester is not registered, because of it's {0}";
    private const int energyRequiermentMaxValue = 20_000;

    private double oreOutput;
    private double energyRequierment;

    protected Harvester(string id, double oreOutput, double energyRequierment)
        : base(id)
    {
        this.OreOutput = oreOutput;
        this.EnergyRequirement = energyRequierment;
    }

    public double OreOutput
    {
        get => this.oreOutput;
        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException(string.Format(ERROR_MESSAGE, nameof(OreOutput)));
            }
            this.oreOutput = value;
        }
    }
    public double EnergyRequirement
    {
        get => this.energyRequierment;
        protected set
        {
            if (value < 0 || value > energyRequiermentMaxValue)
            {
                throw new ArgumentException(string.Format(ERROR_MESSAGE, nameof(EnergyRequirement)));
            }
            this.energyRequierment = value;
        }
    }

    public override string ToString()
    {
        //    //{type} Harvester – {id}
        //    //Ore Output: {oreOutput}
        //    //Energy Requirement: {energyRequired}

        var sb = new StringBuilder();
        sb.AppendLine($"Harvester - {this.Id}");
        sb.AppendLine($"Ore Output: {this.oreOutput}");
        sb.AppendLine($"Energy Requirement: {this.energyRequierment}");
        return sb.ToString().Trim();

    }
}


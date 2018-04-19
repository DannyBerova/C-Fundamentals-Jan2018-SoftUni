using System.Text;

public abstract class Harvester :  IHarvester
{
    private const int DefaultDurability = 1000;
    private const double DurabilityModeLoss = 100;

    protected Harvester(int id, double oreOutput, double energyRequirement)
    {
        this.Id = id;
        this.OreOutput = oreOutput;
        this.EnergyRequirement = energyRequirement;
        this.Durability = DefaultDurability;
    }

    public int Id { get; }

    public double OreOutput { get; }

    public double EnergyRequirement { get; }

    public virtual double Durability { get; protected set; }

    public virtual void Broke()
    {
        this.Durability -= DurabilityModeLoss;
        if (this.Durability < 0)
        {
            throw new System.ArgumentException();
        }
    }

    public double Produce()
    {
        return this.OreOutput;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"{this.GetType().Name}")
            .AppendLine($"Durability: {this.Durability}");

        return sb.ToString().TrimEnd();
    }
}
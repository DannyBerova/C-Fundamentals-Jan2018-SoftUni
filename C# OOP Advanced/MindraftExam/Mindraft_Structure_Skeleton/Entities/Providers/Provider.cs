using System;
using System.Text;

public abstract class Provider : IProvider
{
    private const int DefaultDurability = 1000;
    private const int DurabilityDailyLoss = 100;

    protected Provider(int id, double energyOutput)
    {
        this.Id = id;
        this.EnergyOutput = energyOutput;
        this.Durability = DefaultDurability;
    }

    public int Id { get; }

    public double EnergyOutput { get; }

    public double Durability { get; protected set; }

    public void Broke()
    {
        this.Durability -= DurabilityDailyLoss;
        if (this.Durability < 0)
        {
            throw new ArgumentException();
        }
    }

    public double Produce()
    {
        return this.EnergyOutput;
    }

    public void Repair(double val)
    {
        this.Durability += val;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"{this.GetType().Name}")
            .AppendLine($"Durability: {this.Durability}");

        return sb.ToString().TrimEnd();
    }
}
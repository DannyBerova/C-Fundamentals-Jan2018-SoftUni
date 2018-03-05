using System;
using System.Text;

public abstract class Provider : Miner
{
    private const string ERROR_MESSAGE = "Provider is not registered, because of it's {0}";
    private const int energyOutputMaxValue = 10_000;

    private double energyOutput;

    protected Provider(string id,  double energyOutput)
        : base(id)
    {
        this.EnergyOutput = energyOutput;
    }

    public double EnergyOutput
    {
        get => this.energyOutput;
        protected set
        {
            if (value < 0 || value > 10000)
            {
                throw new ArgumentException(string.Format(ERROR_MESSAGE, nameof(EnergyOutput)));
            }
            this.energyOutput = value;
        }
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Provider - {this.Id}");
        sb.AppendLine($"Energy Output: {this.energyOutput}");
        return sb.ToString().Trim();
    }
}


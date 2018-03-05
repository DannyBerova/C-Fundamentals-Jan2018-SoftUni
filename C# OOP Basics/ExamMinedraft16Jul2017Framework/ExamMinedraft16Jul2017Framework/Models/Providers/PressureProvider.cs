public class PressureProvider : Provider
{
    private double energyOutputMultiplier = 1.5;

    public PressureProvider(string id, double energyOutput) 
        : base(id, energyOutput)
    {
        this.EnergyOutput = this.EnergyOutput * energyOutputMultiplier;
    }

    public override string ToString()
    {
        //{type} Provider – {id}
        //Energy Output: {energyOutput}

        return $"Pressure {base.ToString().Trim()}";
    }
}


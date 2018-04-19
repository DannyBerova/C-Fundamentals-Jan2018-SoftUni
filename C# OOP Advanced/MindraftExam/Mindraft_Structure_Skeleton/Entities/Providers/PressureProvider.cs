public class PressureProvider : Provider
{
    private const int DurabilityLoss = 300;
    private const int EnergyMultiplier = 2;

    public PressureProvider(int id, double energyOutput)
        : base(id, energyOutput * EnergyMultiplier)
    {
        this.Durability -= DurabilityLoss;
    }
}
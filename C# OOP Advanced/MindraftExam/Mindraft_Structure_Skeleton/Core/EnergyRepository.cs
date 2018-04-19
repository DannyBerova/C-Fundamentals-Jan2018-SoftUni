public class EnergyRepository : IEnergyRepository
{
    public double EnergyStored { get; private set; }

    public void StoreEnergy(double energy)
    {
        this.EnergyStored += energy;
    }

    public bool TakeEnergy(double energyNeeded)
    {
        var hasEnoughEnergy = this.EnergyStored >= energyNeeded;

        if (hasEnoughEnergy)
        {
            this.EnergyStored -= energyNeeded;
            return true;
        }

        return false;
    }
}
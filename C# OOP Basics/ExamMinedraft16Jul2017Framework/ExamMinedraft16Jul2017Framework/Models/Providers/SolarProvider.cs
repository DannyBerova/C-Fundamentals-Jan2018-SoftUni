public class SolarProvider : Provider
{
    public SolarProvider(string id, double energyOutput) 
        : base(id, energyOutput)
    {
    }

    public override string ToString()
    {
        //{type} Provider – {id}
        //Energy Output: {energyOutput}

        return $"Solar {base.ToString().Trim()}";
    }
}


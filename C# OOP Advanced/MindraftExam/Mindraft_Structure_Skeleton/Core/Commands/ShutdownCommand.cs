using System.Collections.Generic;
using System.Text;

public class ShutdownCommand : Command
{
    private IProviderController providerController;
    private IHarvesterController harvesterController;

    public ShutdownCommand(IList<string> arguments, IHarvesterController harvesterController, IProviderController providerController) 
        : base(arguments)
    {
        this.harvesterController = harvesterController;
        this.providerController = providerController;
    }

    public override string Execute()
    {
        var result = new StringBuilder();
        result.AppendLine(string.Format(Constants.SystemShutdown));

        result.AppendLine(string.Format(Constants.TotalEnergyProduced, providerController.TotalEnergyProduced));

        result.AppendLine(string.Format(Constants.TotalMinedOre, harvesterController.OreProduced));

        return result.ToString().Trim();
    }
}
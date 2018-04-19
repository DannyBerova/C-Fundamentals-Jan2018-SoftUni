using System.Collections.Generic;
using System.Linq;

public class RegisterCommand : Command
{
    private IHarvesterController harvesterController;
    private IProviderController providerController;

    public RegisterCommand(IList<string> arguments, IHarvesterController harvesterController, IProviderController providerController) 
        : base(arguments)
    {
        this.harvesterController = harvesterController;
        this.providerController = providerController;
    }

    public override string Execute()
    {
        var baseType = this.Arguments[0];

        var commandArgs = this.Arguments.Skip(1).ToList();

        var result = string.Empty;

        switch (baseType)
        {
            case nameof(Harvester):
                result = this.harvesterController.Register(commandArgs);
                break;
            case nameof(Provider):
                result = this.providerController.Register(commandArgs);
                break;
            default:
                break;
        }

        return result;
    }
}
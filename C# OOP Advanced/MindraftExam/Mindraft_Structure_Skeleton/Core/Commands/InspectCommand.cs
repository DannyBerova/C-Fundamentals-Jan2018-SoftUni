using System;
using System.Collections.Generic;
using System.Linq;

public class InspectCommand : Command
{
    private IHarvesterController harvesterController;
    private IProviderController providerController;

    public InspectCommand(IList<string> arguments, IHarvesterController harvesterController, IProviderController providerController) 
        : base(arguments)
    {
        this.harvesterController = harvesterController;
        this.providerController = providerController;
    }

    public override string Execute()
    {
        var id = int.Parse(this.Arguments[0]);

        var allEntities = this.harvesterController
            .Entities.ToArray()
            .Concat(this.providerController
                .Entities)
            .ToArray();

        var neededEntity = allEntities.FirstOrDefault(e => e.Id == id);

        if (neededEntity == null)
        {
            return string.Format(Constants.EntityNotFound, id);
        }

        var entityToString = $"{neededEntity.GetType().Name}"
                             + Environment.NewLine
                             + $"Durability: {neededEntity.Durability}";

        return neededEntity.ToString();
    }
}
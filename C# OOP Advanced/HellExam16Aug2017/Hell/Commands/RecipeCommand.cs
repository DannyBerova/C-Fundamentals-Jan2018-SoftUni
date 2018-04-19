using System.Collections.Generic;

public class RecipeCommand : AbstractCommand
{
    public RecipeCommand(IList<string> argsList, IManager manager) : base(argsList, manager)
    {
    }

    public override string Execute()
    {
        return base.Manager.AddRecipe(ArgsList);
    }
}



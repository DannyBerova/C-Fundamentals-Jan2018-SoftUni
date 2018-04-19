using System.Collections.Generic;

public class ItemCommand : AbstractCommand
{
    public ItemCommand(IList<string> argsList, IManager manager) : base(argsList, manager)
    {
    }

    public override string Execute()
    {
        return base.Manager.AddItem(ArgsList);
    }
}


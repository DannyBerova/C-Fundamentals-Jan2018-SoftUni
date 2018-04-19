using System.Collections.Generic;

public class InspectCommand : AbstractCommand
{
    public InspectCommand(IList<string> argsList, IManager manager) : base(argsList, manager)
    {
    }

    public override string Execute()
    {
        return base.Manager.Inspect(ArgsList);
    }
}


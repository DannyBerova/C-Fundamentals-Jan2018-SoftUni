using System.Collections.Generic;

public abstract class AbstractCommand : ICommand
{
    protected AbstractCommand(IList<string> argsList, IManager manager)
    {
        this.ArgsList = argsList;
        this.Manager = manager;
    }

    public IList<string> ArgsList { get; private set; }

    public IManager Manager { get; private set; }

    public abstract string Execute();


}


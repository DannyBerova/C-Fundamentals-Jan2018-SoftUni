using System.Collections.Generic;

public abstract class Command : ICommand
{
    public Command(IList<string> arguments)
    {
        this.Arguments = arguments;
    }

    public IList<string> Arguments { get; }

    public abstract string Execute();
}
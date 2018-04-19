using System;
using System.Collections.Generic;

public abstract class Command : ICommand
{
    protected Command(IList<string> argumets)
    {
        this.Arguments = argumets;
    }

    public IList<string> Arguments { get; }

    public abstract string Execute();
}
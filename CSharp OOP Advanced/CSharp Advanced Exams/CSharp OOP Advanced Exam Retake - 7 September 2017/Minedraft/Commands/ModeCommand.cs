using System.Collections.Generic;

public class ModeCommand : Command
{
    [Inject]
    private IHarvesterController harvesterController;

    public ModeCommand(IList<string> argumets, IHarvesterController harvesterController) :
        base(argumets)
    {
        this.harvesterController = harvesterController;
    }

    public override string Execute()
    {
        string mode = this.Arguments[0];
        return this.harvesterController.ChangeMode(mode);
    }
}
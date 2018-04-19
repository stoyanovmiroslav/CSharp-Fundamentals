using System.Collections.Generic;

public class RepairCommand : Command
{
    [Inject]
    private IProviderController providerController;

    public RepairCommand(IList<string> argumets, IProviderController providerController) 
        :base(argumets)
    {
        this.providerController = providerController;
    }

    public override string Execute()
    {
        double value = double.Parse(this.Arguments[0]);
        return this.providerController.Repair(value);
    }
}
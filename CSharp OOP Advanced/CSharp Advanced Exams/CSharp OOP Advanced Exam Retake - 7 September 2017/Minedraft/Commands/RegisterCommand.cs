using System.Collections.Generic;
using System.Linq;

public class RegisterCommand : Command
{
    [Inject]
    private IHarvesterController harvesterController;
    [Inject]
    private IProviderController providerController;

    public RegisterCommand(IList<string> argumets, IHarvesterController harvesterController, IProviderController providerController) : base(argumets)
    {
        this.harvesterController = harvesterController;
        this.providerController = providerController;
    }

    public override string Execute()
    {
        string type = this.Arguments[0];
        string result = string.Empty;

        if (type == "Harvester")
        {
            result = harvesterController.Register(this.Arguments.Skip(1).ToList());
        }
        else
        {
            result = providerController.Register(this.Arguments.Skip(1).ToList());
        }

        return result;
    }
}
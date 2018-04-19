using System.Collections.Generic;
using System.Text;

public class ShutdownCommand : Command
{
    [Inject]
    private IHarvesterController harvesterController;
    [Inject]
    private IProviderController providerController;

    public ShutdownCommand(IList<string> argumets, IHarvesterController harvesterController, IProviderController providerController) :base(argumets)
    {
        this.harvesterController = harvesterController;
        this.providerController = providerController;
    }

    public override string Execute()
    {
        var sb = new StringBuilder();
        sb.AppendLine(Constants.Shutdown);
        sb.AppendLine(string.Format(Constants.TotalEnergyProduced, this.providerController.TotalEnergyProduced));
        sb.Append(string.Format(Constants.TotalMinedOre, this.harvesterController.OreProduced));

        return sb.ToString().Trim();
    }
}
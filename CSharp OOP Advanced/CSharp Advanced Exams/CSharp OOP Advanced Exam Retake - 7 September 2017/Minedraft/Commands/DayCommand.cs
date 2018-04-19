using System.Collections.Generic;
using System.Text;

public class DayCommand : Command
{
    [Inject]
    private IHarvesterController harvesterController;
    [Inject]
    private IProviderController providerController;

    public DayCommand(IList<string> argumets, IHarvesterController harvesterController, IProviderController providerController) :
        base(argumets)
    {
        this.harvesterController = harvesterController;
        this.providerController = providerController;
    }

    public override string Execute()
    {
        string produceEnergy = this.providerController.Produce();
        string minedOres = this.harvesterController.Produce();

        var sb = new StringBuilder();
        sb.AppendLine(produceEnergy);
        sb.Append(minedOres);

        return sb.ToString().Trim();
    }
}
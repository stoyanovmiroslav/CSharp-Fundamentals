using System.Collections.Generic;
using System.Linq;
using System.Text;

public class InspectCommand : Command
{
    [Inject]
    private IHarvesterController harvesterController;
    [Inject]
    private IProviderController providerController;

    public InspectCommand(IList<string> argumets, IHarvesterController harvesterController, IProviderController providerController) :
        base(argumets)
    {
        this.harvesterController = harvesterController;
        this.providerController = providerController;
    }

    public override string Execute()
    {
        var id = this.Arguments[0];
        var sb = new StringBuilder();
        
        if (this.providerController.Entities.Any(e => e.ID.ToString() == id))
        {
            var provider = this.providerController.Entities.FirstOrDefault(e => e.ID.ToString() == id);
            sb.AppendLine(provider.ToString());
            sb.AppendLine($"Durability: {provider.Durability.ToString()}");
        }

        if (this.harvesterController.Entities.Any(e => e.ID.ToString() == id))
        {
            var harvester = this.harvesterController.Entities.FirstOrDefault(e => e.ID.ToString() == id);
            sb.AppendLine(harvester.ToString());
            sb.AppendLine($"Durability: {harvester.Durability.ToString()}");
        }

        if (string.IsNullOrWhiteSpace(sb.ToString()))
        {
            sb.AppendLine(string.Format(Constants.NoEntityFound, id));
        }

        return sb.ToString().Trim();
    }
}
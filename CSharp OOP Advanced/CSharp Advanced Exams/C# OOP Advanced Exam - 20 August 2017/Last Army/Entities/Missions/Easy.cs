using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Easy : Mission
{
    private const string EasyMissionName = "Suppression of civil rebellion";
    private const double EasyEnduranceRequired = 20;
    private const double EasyWearLevelDecrease = 30;

    public Easy(double scoreToComplete) : base(scoreToComplete)
    {
    }

    public override string Name => EasyMissionName;

    public override double EnduranceRequired => EasyEnduranceRequired;

    public override double WearLevelDecrement => EasyWearLevelDecrease;
}
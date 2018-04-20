using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Medium : Mission
{
    private const string MediumMissionName = "Capturing dangerous criminals";
    private const double MediumEnduranceRequired = 50;
    private const double MediumWearLevelDecrease = 50;

    public Medium(double scoreToComplete) : base(scoreToComplete)
    {
    }

    public override string Name => MediumMissionName;

    public override double EnduranceRequired => MediumEnduranceRequired;

    public override double WearLevelDecrement => MediumWearLevelDecrease;
}
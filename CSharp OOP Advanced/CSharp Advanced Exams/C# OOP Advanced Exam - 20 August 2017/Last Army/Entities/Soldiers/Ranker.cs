using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Ranker : Soldier
{
    private const double OverallSkillMiltiplier = 1.5;

    public Ranker(string name, int age, double experience, double endurance)
        : base(name, age, experience, endurance)
    {
    }



    private readonly List<string> weaponsAllowed = new List<string>
    {
            "Gun",
            "AutomaticMachine",
            "Helmet"
    };

    public override double OverallSkill => base.OverallSkill * OverallSkillMiltiplier;

    protected override IReadOnlyList<string> WeaponsAllowed
    {
        get { return weaponsAllowed; }
    }
}
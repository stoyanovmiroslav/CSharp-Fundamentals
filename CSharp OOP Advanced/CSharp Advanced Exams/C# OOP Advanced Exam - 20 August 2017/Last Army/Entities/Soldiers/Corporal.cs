using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Corporal : Soldier
{
    private const double OverallSkillMiltiplier = 2.5;

    public Corporal(string name, int age, double experience, double endurance)
            : base(name, age, experience, endurance)
    {
    }

    private readonly List<string> weaponsAllowed = new List<string>
        {
            "Gun",
            "AutomaticMachine",
            "MachineGun",
            "Helmet",
            "Knife"
        };

    public override double OverallSkill => base.OverallSkill * OverallSkillMiltiplier;

    protected override IReadOnlyList<string> WeaponsAllowed
    {
        get { return weaponsAllowed; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class WareHouse : IWareHouse
{
    private readonly AmmunitionFactory ammunitionFactory;
    private Dictionary<string, int> ammunitionsDictionary;

    public WareHouse()
    {
        this.ammunitionsDictionary = new Dictionary<string, int>();
        this.ammunitionFactory = new AmmunitionFactory();
    }

    public void EquipArmy(IArmy army)
    {
        foreach (ISoldier soldier in army.Soldiers)
        {
            this.TryEquipSoldier(soldier);
        }
    }

    public bool TryEquipSoldier(ISoldier soldier)
    {
        bool isEquipped = true;

        List<string> missingWeapons = soldier.Weapons.Where(w => w.Value == null).Select(w => w.Key).ToList();
        foreach (string weaponName in missingWeapons)
        {
            if (this.ammunitionsDictionary.ContainsKey(weaponName) && ammunitionsDictionary[weaponName] > 0)
            {
                soldier.Weapons[weaponName] = this.ammunitionFactory.CreateAmmunition(weaponName);
                this.ammunitionsDictionary[weaponName]--;
            }
            else
            {
                isEquipped = false;
            }
        }

        return isEquipped;
    }

    public void AddAmmunitions(string name, int number)
    {
        if (this.ammunitionsDictionary.ContainsKey(name) == false)
        {
            this.ammunitionsDictionary[name] = number;
        }
        else
        {
            this.ammunitionsDictionary[name] += number;
        }
    }
}
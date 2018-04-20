using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IWareHouse
{
    void AddAmmunitions(string name, int quantity);

    void EquipArmy(IArmy army);

    bool TryEquipSoldier(ISoldier soldier);
}

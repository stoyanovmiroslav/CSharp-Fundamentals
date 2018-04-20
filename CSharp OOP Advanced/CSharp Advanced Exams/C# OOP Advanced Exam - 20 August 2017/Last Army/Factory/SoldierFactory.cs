using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class SoldierFactory : ISoldierFactory
{
    public ISoldier CreateSoldier(string soldierTypeName, string name, int age, double experience, double endurance)
    {
        Type type = Type.GetType(soldierTypeName);
        var item = (ISoldier)Activator.CreateInstance(Type.GetType(soldierTypeName), name, age, experience, endurance);
        return item;
    }
}
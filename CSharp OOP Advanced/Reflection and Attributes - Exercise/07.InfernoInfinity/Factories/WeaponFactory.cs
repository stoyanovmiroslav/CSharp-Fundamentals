using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _07.InfernoInfinity.Weapons;

namespace _07.InfernoInfinity.Factories
{
    public class WeaponFactory
    {
        public Weapon CreateWeapon(string[] commandArgs)
        {
            string[] typeArgs = commandArgs[0].Split();
            string rarity = typeArgs[0];
            string weaponType = typeArgs[1];
            string weaponName = commandArgs[1];

            switch (weaponType)
            {
                case "Axe":
                     return new Axe(weaponName, rarity);
                case "Sword":
                    return new Sword(weaponName, rarity);
                case "Knife":
                    return new Knife(weaponName, rarity);
                    default:
                        throw new ArgumentException("Invalid Weapon Type!");
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _07.InfernoInfinity.Factories;
using _07.InfernoInfinity.Gems;
using _07.InfernoInfinity.Weapons;

namespace _07.InfernoInfinity.Core
{
    public class Engine
    {
        private WeaponFactory weaponFactory;
        private GemFactory gemFactory;
        private List<Weapon> weapons;

        public Engine()
        {
            this.weaponFactory = new WeaponFactory();
            this.gemFactory = new GemFactory();
            this.weapons = new List<Weapon>();
        }

        public void Run()
        {
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] commandArgs = input.Split(";");
                string command = commandArgs[0];

                try
                {
                    CommandInterpreter(command, commandArgs);
                }
                catch (ArgumentException argEx)
                {
                    Console.WriteLine(argEx.Message);
                }
            }
        }

        private void CommandInterpreter(string command, string[] commandArgs)
        {
            switch (command)
            {
                case "Create":
                    Weapon weapon = weaponFactory.CreateWeapon(commandArgs.Skip(1).ToArray());
                    weapons.Add(weapon);
                    break;
                case "Add":
                    Weapon weaponAdd = weapons.FirstOrDefault(w => w.Name == commandArgs[1]);
                    Gem gem = gemFactory.CreateGem(commandArgs.Skip(3).ToArray());
                    weaponAdd.Add(int.Parse(commandArgs[2]), gem);
                    break;
                case "Remove":
                    Weapon weaponRemove = weapons.FirstOrDefault(w => w.Name == commandArgs[1]);
                    weaponRemove.Remove(int.Parse(commandArgs[2]));
                    break;
                case "Print":
                    Weapon weaponPrint = weapons.FirstOrDefault(w => w.Name == commandArgs[1]);
                    Console.WriteLine(weaponPrint);
                    break;
            }
        }
    }
}
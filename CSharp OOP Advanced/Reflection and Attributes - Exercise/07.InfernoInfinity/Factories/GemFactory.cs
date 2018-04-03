using System;
using System.Collections.Generic;
using System.Text;
using _07.InfernoInfinity.Gems;

namespace _07.InfernoInfinity.Factories
{
    public class GemFactory
    {
        public Gem CreateGem(string[] commandArg)
        {
            string[] gemArgs = commandArg[0].Split();
            string gemType = gemArgs[1];
            string clarity = gemArgs[0];

            switch (gemType)
            {
                case "Ruby":
                    return new Ruby(clarity);
                case "Amethyst":
                    return new Amethyst(clarity);
                case "Emerald":
                    return new Emerald(clarity);
                default:
                    throw new ArgumentException("Invalid Gem Type!");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using _07.InfernoInfinity.Core;
using _07.InfernoInfinity.Factories;
using _07.InfernoInfinity.Gems;
using _07.InfernoInfinity.Weapons;

namespace _07.InfernoInfinity
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Engine engine = new Engine();
            engine.Run();
        }
    }
}
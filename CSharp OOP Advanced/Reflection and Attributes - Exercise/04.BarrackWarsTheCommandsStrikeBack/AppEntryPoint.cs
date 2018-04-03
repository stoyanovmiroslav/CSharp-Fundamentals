using System;
using _04.BarrackWarsTheCommandsStrikeBack.Contracts;
using _04.BarrackWarsTheCommandsStrikeBack.Core;
using _04.BarrackWarsTheCommandsStrikeBack.Core.Factories;
using _04.BarrackWarsTheCommandsStrikeBack.Data;

namespace _04.BarrackWarsTheCommandsStrikeBack
{
    class AppEntryPoint
    {
        static void Main(string[] args)
        {
            IRepository repository = new UnitRepository();
            IUnitFactory unitFactory = new UnitFactory();
            IRunnable engine = new Engine(repository, unitFactory);
            engine.Run();
        }
    }
}
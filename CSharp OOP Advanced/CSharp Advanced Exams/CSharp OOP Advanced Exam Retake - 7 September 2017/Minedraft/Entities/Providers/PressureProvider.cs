public class PressureProvider : Provider
{
    private const double DurabilityDecreased = 300;

    public PressureProvider(int id, double energyOutput) 
        : base(id, energyOutput)
    {
        this.Durability -= DurabilityDecreased;
        this.EnergyOutput *= 2;
    }
}
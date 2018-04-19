using NUnit.Framework;
using System;
using System.Collections.Generic;

[TestFixture]
public class ProviderControllerTests
{
    private EnergyRepository energyRepository;
    private ProviderController providerController;

    [SetUp]
    [Test]
    public void SetUp()
    {
        this.energyRepository = new EnergyRepository();
        this.providerController = new ProviderController(energyRepository);

    }

    [Test]
    public void ProduseProviderTotalEnergy()
    {
        providerController.Register(new List<string> { "Solar", "80", "100" });
        providerController.Register(new List<string> { "Solar", "81", "100" });

        for (int i = 0; i < 2; i++)
        {
            providerController.Produce();
        }

        Assert.That(providerController.TotalEnergyProduced, Is.EqualTo(400));
    }

    [Test]
    public void DeleteBrokenProvider()
    {
        providerController.Register(new List<string> { "Solar", "80", "100" });

        for (int i = 0; i <= 15; i++)
        {
            providerController.Produce();
        }

        Assert.That(providerController.Entities.Count, Is.EqualTo(0));
    }
}

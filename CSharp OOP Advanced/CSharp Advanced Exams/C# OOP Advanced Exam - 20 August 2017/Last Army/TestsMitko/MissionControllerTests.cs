
using NUnit.Framework;

public class MissionControllerTests
{


    [Test]
    public void Test()
    {
        var army = new Army();
        var af = new AmmunitionFactory();
        var wareHouse = new WareHouse(af);
        var soldierFactory = new SoldierFactory();
        var missionFactory = new MissionFactory();
        var missionController = new MissionController(army, wareHouse);
        var writer = new ConsoleWriter();
        var gamecontroller = new GameController(army, wareHouse, missionController, soldierFactory, missionFactory, writer);

        var mission = new Easy(1);
        string result = string.Empty;

        for (int i = 0; i < 4; i++)
        {
            result = missionController.PerformMission(mission).Trim();
        }

        Assert.IsTrue(result.StartsWith("Mission declined - Suppression of civil rebellion"));
    }

    [Test]
    public void TestOnHoldMessage()
    {
        var army = new Army();
        var af = new AmmunitionFactory();
        var wareHouse = new WareHouse(af);
        var soldierFactory = new SoldierFactory();
        var missionFactory = new MissionFactory();
        var missionController = new MissionController(army, wareHouse);
        var writer = new ConsoleWriter();
        var gamecontroller = new GameController(army, wareHouse, missionController, soldierFactory, missionFactory, writer);

        var mission = new Easy(1);

        var result = missionController.PerformMission(mission).Trim();

        Assert.That(result, Is.EqualTo("Mission on hold - Suppression of civil rebellion"));
    }

    [Test]
    public void TestSuccessMessage()
    {
        var army = new Army();
        var af = new AmmunitionFactory();
        var wareHouse = new WareHouse(af);
        var soldierFactory = new SoldierFactory();
        var missionFactory = new MissionFactory();
        var missionController = new MissionController(army, wareHouse);
        var writer = new ConsoleWriter();
        var gamecontroller = new GameController(army, wareHouse, missionController, soldierFactory, missionFactory, writer);

        var mission = new Easy(0);

        var result = missionController.PerformMission(mission).Trim();

        Assert.That(result, Is.EqualTo("Mission completed - Suppression of civil rebellion"));
    }
}
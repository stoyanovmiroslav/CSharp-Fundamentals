using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class MissionControllerTests
    {
        private IWareHouse wareHouse;
        private IArmy army;
        private MissionController missionController;
        
        [SetUp]
        public void SetUp()
        {
            wareHouse = new WareHouse();
            army = new Army();
            missionController = new MissionController(army, wareHouse);
        }

        [Test]
        public void PerformMissionFailedMissions()
        {
            IMission mission = new Easy(30);

            this.missionController.Missions.Enqueue(mission);
            this.missionController.Missions.Enqueue(mission);
            this.missionController.Missions.Enqueue(mission);
            this.missionController.PerformMission(mission);
            this.missionController.PerformMission(mission);

            Assert.That(this.missionController.Missions.Count, Is.EqualTo(3));
            Assert.That(this.missionController.FailedMissionCounter, Is.EqualTo(2));
        }

        [Test]
        public void FaildMissinOnHold()
        {
            IMission mission = new Hard(30);

            this.missionController.Missions.Enqueue(mission);
            this.missionController.Missions.Enqueue(mission);
            this.missionController.FailMissionsOnHold();

            Assert.That(this.missionController.FailedMissionCounter, Is.EqualTo(2));
        }

        [Test]
        public void FaildMissinOnHoldZero()
        {
            IMission mission = new Hard(30);

            this.missionController.FailMissionsOnHold();

            Assert.That(this.missionController.FailedMissionCounter, Is.EqualTo(0));
        }


        [Test]
        public void CompleteMission()
        {
            IMission mission = new Medium(40);

            this.wareHouse.AddAmmunitions("Gun", 10);
            this.wareHouse.AddAmmunitions("AutomaticMachine", 10);
            this.wareHouse.AddAmmunitions("Helmet", 10);

            var soldier = new Ranker("Soldier", 30, 50, 50);
            this.army.AddSoldier(soldier);
            this.wareHouse.EquipArmy(army);

            string message = $"Mission completed - {mission.Name}";
            Assert.That(missionController.PerformMission(mission).Trim(), Is.EqualTo(message));
        }
    }
}

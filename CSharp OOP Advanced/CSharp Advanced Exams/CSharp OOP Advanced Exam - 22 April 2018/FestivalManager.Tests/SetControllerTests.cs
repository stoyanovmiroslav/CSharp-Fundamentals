namespace FestivalManager.Tests
{
    using FestivalManager.Core.Controllers;
    using FestivalManager.Core.Controllers.Contracts;
    using FestivalManager.Entities;
    using FestivalManager.Entities.Contracts;
    using FestivalManager.Entities.Instruments;
    using FestivalManager.Entities.Sets;
    using System;
    using NUnit.Framework;

	[TestFixture]
	public class SetControllerTests
    {
        private ISetController setController;
        private IStage stage;

        [SetUp]
	    public void SetUp()
	    {
            this.stage = new Stage();
            this.setController = new SetController(stage);
        }

        [Test]
        public void PerformSetsUnsuccessful()
        {
            ISet setShort = new Short("Set1");
            this.stage.AddSet(setShort);

            string result = this.setController.PerformSets();
            string expectedResult = "1. Set1:" + "\r\n" + "-- Did not perform";

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void PerformSetsSuccessful()
        {
            ISet setShort = new Short("Set1");
            Performer performer = new Performer("Ivan", 20);
            IInstrument instrumentGuitar = new Guitar();
            ISong song = new Song("Song1", new TimeSpan(0, 1, 2));

            performer.AddInstrument(instrumentGuitar);
            this.stage.AddSet(setShort);
            this.stage.AddPerformer(performer);
            this.stage.AddSong(song);

            setShort.AddSong(song);
            setShort.AddPerformer(performer);

            string result = this.setController.PerformSets();
            string expectedResult = "1. Set1:\r\n-- 1. Song1 (01:02)\r\n-- Set Successful";

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void PerformSetsDecreaseWear()
        {
            ISet setShort = new Short("Set1");
            Performer performer = new Performer("Ivan", 20);
            IInstrument instrumentGuitar = new Guitar();
            ISong song = new Song("Song1", new TimeSpan(0, 1, 2));

            performer.AddInstrument(instrumentGuitar);
            this.stage.AddSet(setShort);
            this.stage.AddPerformer(performer);
            this.stage.AddSong(song);

            setShort.AddSong(song);
            setShort.AddPerformer(performer);

            this.setController.PerformSets();
            Assert.That(instrumentGuitar.Wear, Is.EqualTo(40));
        }
    }
}
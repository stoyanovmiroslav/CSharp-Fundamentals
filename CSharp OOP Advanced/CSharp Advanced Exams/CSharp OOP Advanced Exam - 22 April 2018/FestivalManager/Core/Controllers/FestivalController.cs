namespace FestivalManager.Core.Controllers
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Contracts;
    using Entities.Contracts;
    using FestivalManager.Entities.Factories;
    using FestivalManager.Entities.Factories.Contracts;

    public class FestivalController : IFestivalController
    {
        private const string TimeFormat = "mm\\:ss";
        private const string TimeFormatLong = "{0:2D}:{1:2D}";
        private const string TimeFormatThreeDimensional = "{0:3D}:{1:3D}";

        private readonly IStage stage;
        private IInstrumentFactory instrumentFactory;
        private IPerformerFactory performerFactory;
        private ISetFactory setFactory;
        private SongFactory songFactory;

        public FestivalController(IStage stage)
        {
            this.stage = stage;
            this.instrumentFactory = new InstrumentFactory();
            this.performerFactory = new PerformerFactory();
            this.setFactory = new SetFactory();
            this.songFactory = new SongFactory();

        }
        
        public string RegisterSet(string[] args)
        {
            var setName = args[0];
            var setType = args[1];

            ISet set = setFactory.CreateSet(setName, setType);
            stage.AddSet(set);
            return $"Registered {setType} set";
        }
        
        public string SignUpPerformer(string[] args)
        {
            var name = args[0];
            var age = int.Parse(args[1]);

            var instrumenti = args.Skip(2).ToArray();

            var instrumenti2 = instrumenti
                .Select(i => this.instrumentFactory.CreateInstrument(i))
                .ToArray();

            var performer = this.performerFactory.CreatePerformer(name, age);

            foreach (var instrument in instrumenti2)
            {
                performer.AddInstrument(instrument);
            }

            this.stage.AddPerformer(performer);

            return $"Registered performer {performer.Name}";
        }

        public string RegisterSong(string[] args)
        {
            string name = args[0];
            string time = args[1];
            TimeSpan duration = TimeSpan.ParseExact(time, "mm\\:ss", CultureInfo.InvariantCulture);

            ISong song = songFactory.CreateSong(name, duration);
            stage.AddSong(song);
            return $"Registered song {name} ({time})";
        }

        public string AddSongToSet(string[] args)
        {
            var songName = args[0];
            var setName = args[1];

            if (!this.stage.HasSet(setName))
            {
                throw new InvalidOperationException("Invalid set provided");
            }

            if (!this.stage.HasSong(songName))
            {
                throw new InvalidOperationException("Invalid song provided");
            }

            var set = this.stage.GetSet(setName);
            var song = this.stage.GetSong(songName);

            set.AddSong(song);

            return $"Added {song} to {set.Name}";
        }
        
        public string AddPerformerToSet(string[] args)
        {
            var performerName = args[0];
            var setName = args[1];

            if (!this.stage.HasPerformer(performerName))
            {
                throw new InvalidOperationException("Invalid performer provided");
            }

            if (!this.stage.HasSet(setName))
            {
                throw new InvalidOperationException("Invalid set provided");
            }

            var performer = this.stage.GetPerformer(performerName);
            var set = this.stage.GetSet(setName);

            set.AddPerformer(performer);

            return $"Added {performer.Name} to {set.Name}";
        }

        public string RepairInstruments(string[] args)
        {
            var instrumentsToRepair = this.stage.Performers
                .SelectMany(p => p.Instruments)
                .Where(i => i.Wear < 100)
                .ToArray();

            foreach (var instrument in instrumentsToRepair)
            {
                instrument.Repair();
            }

            return $"Repaired {instrumentsToRepair.Length} instruments";
        }

        public string ProduceReport()
        {
            StringBuilder result = new StringBuilder();

            var totalFestivalLength = new TimeSpan(this.stage.Sets.Sum(s => s.ActualDuration.Ticks));

         
             result.AppendLine($"Festival length: {totalFestivalLength.TotalMinutes:00}:{totalFestivalLength.Seconds:00}");

            foreach (var set in this.stage.Sets)
            {
                result.AppendLine($"--{set.Name} ({set.ActualDuration.TotalMinutes:00}:{set.ActualDuration.Seconds:00}):");

                var performersOrderedDescendingByAge = set.Performers.OrderByDescending(p => p.Age);
                foreach (var performer in performersOrderedDescendingByAge)
                {
                    var instruments = string.Join(", ", performer.Instruments
                        .OrderByDescending(i => i.Wear));

                    result.AppendLine($"---{performer.Name} ({instruments})");
                }

                if (!set.Songs.Any())
                    result.AppendLine("--No songs played");
                else
                {
                    result.AppendLine("--Songs played:");
                    foreach (var song in set.Songs)
                    {
                        result.AppendLine($"----{song.Name} ({song.Duration.ToString(TimeFormat)})");
                    }
                }
            }

            return result.ToString().Trim();
        }
    }
}
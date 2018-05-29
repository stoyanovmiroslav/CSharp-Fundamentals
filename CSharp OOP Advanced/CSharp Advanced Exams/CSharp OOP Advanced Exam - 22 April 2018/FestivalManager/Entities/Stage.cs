namespace FestivalManager.Entities
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;

    public class Stage : IStage
    {
        private readonly List<ISet> sets;
        private readonly List<ISong> songs;
        private readonly List<IPerformer> performers;

        public Stage()
        {
            this.sets = new List<ISet>();
            this.songs = new List<ISong>();
            this.performers = new List<IPerformer>();
        }

        public IReadOnlyCollection<ISet> Sets
        {
            get { return sets; }
        }

        public IReadOnlyCollection<ISong> Songs
        {
            get { return songs; }
        }

        public IReadOnlyCollection<IPerformer> Performers
        {
            get { return performers; }
        }

        public void AddPerformer(IPerformer performer)
        {
            this.performers.Add(performer);
        }

        public void AddSet(ISet performer)
        {
            this.sets.Add(performer);
        }

        public void AddSong(ISong song)
        {
            this.songs.Add(song);
        }

        public IPerformer GetPerformer(string name)
        {
            IPerformer performer = performers.FirstOrDefault(p => p.Name == name);
            return performer;
        }

        public ISet GetSet(string name)
        {
            ISet set = sets.FirstOrDefault(s => s.Name == name);
            return set;
        }

        public ISong GetSong(string name)
        {
            ISong song = songs.FirstOrDefault(s => s.Name == name);
            return song;
        }

        public bool HasPerformer(string name)
        {
            IPerformer performer = performers.FirstOrDefault(p => p.Name == name);
            if (performer == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool HasSet(string name)
        {
            ISet set = sets.FirstOrDefault(p => p.Name == name);
            if (set == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool HasSong(string name)
        {
            ISong song = songs.FirstOrDefault(p => p.Name == name);
            if (song == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}

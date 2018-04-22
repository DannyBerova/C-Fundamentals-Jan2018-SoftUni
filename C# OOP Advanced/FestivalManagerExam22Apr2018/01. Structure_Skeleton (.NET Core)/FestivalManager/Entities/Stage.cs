namespace FestivalManager.Entities
{
    using System.Linq;
    using System.Collections.Generic;
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
	   public IReadOnlyCollection<ISet> Sets => this.sets;

	   public IReadOnlyCollection<ISong> Songs => this.songs;

	   public IReadOnlyCollection<IPerformer> Performers => this.performers;

	    public IPerformer GetPerformer(string name)
	    {
	      return this.performers.SingleOrDefault(p => p.Name == name);
	    }

	    public ISong GetSong(string name)
	    {
	        return this.songs.SingleOrDefault(s => s.Name == name);
        }

	    public ISet GetSet(string name)
	    {
	        return this.sets.SingleOrDefault(set => set.Name == name);
        }

	    public void AddPerformer(IPerformer performer)
	    {
	        this.performers.Add(performer);
	    }

	    public void AddSong(ISong song)
	    {
	       this.songs.Add(song);
	    }

	    public void AddSet(ISet set)
	    {
	        this.sets.Add(set);
	    }

	    public bool HasPerformer(string name)
	    {
	        return this.performers.SingleOrDefault(p => p.Name == name) != null;
	    }

	    public bool HasSong(string name)
	    {
	        return this.songs.SingleOrDefault(s => s.Name == name) != null;
        }

	    public bool HasSet(string name)
	    {
	        return this.sets.SingleOrDefault(set => set.Name == name) != null;
        }

    }
}

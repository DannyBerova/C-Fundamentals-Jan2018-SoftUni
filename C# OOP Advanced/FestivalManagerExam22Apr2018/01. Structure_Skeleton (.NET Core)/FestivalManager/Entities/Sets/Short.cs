namespace FestivalManager.Entities.Sets
{
	using System;

	public class Short : Set
	{
	    public Short(string name)
	        : base(name, TimeSpan.FromMinutes(15))
	    {
	        this.Name = name;
	    }
    }
}
namespace FestivalManager.Entities.Sets
{
	using System;

	public class Medium : Set
	{
		public Medium(string name)
			: base(name, TimeSpan.FromMinutes(40))
		{
			this.Name=name;
		}
	}
}
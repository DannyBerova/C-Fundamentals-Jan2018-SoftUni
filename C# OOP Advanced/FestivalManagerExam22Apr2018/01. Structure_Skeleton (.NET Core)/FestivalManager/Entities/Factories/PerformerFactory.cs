namespace FestivalManager.Entities.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Contracts;
	using Entities.Contracts;

	public class PerformerFactory : IPerformerFactory
	{
		public IPerformer CreatePerformer(string name, int age)
		{
		    var type = nameof(Performer);
		    Type performerType = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(t => t.Name == type); 
		    var ctors = performerType.GetConstructors(BindingFlags.Public | BindingFlags.Instance);
		    IPerformer performer = (IPerformer)ctors[0].Invoke(new object[] { name, age });

		    return performer;
        }
	}
}
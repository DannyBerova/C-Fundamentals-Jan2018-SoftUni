namespace FestivalManager.Entities.Factories
{
	using System;
	using System.Linq;
	using System.Reflection;
	using Contracts;
	using Entities.Contracts;

	public class InstrumentFactory : IInstrumentFactory
	{
		public IInstrument CreateInstrument(string type)
		{
		    var typeToCreate = Assembly.GetCallingAssembly().GetTypes().Single(t => t.Name == type);
		    return (IInstrument)Activator.CreateInstance(typeToCreate);
        }
	}
}
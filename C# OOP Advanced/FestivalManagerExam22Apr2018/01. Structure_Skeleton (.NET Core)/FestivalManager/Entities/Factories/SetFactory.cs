namespace FestivalManager.Entities.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Contracts;
	using Entities.Contracts;

	public class SetFactory : ISetFactory
	{
		public ISet CreateSet(string name, string type)
		{
		    Type setType = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(t => t.Name == type); //take type
		    var ctors = setType.GetConstructors(BindingFlags.Public | BindingFlags.Instance); // take constructors
		    ISet setInvoke = (ISet)ctors[0].Invoke(new object[] { name }); //invoke type's constructor to create new instance

		    return setInvoke;
        }
	}




}

namespace _03BarracksFactory.Core.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using _03BarracksFactory.Contracts;


    public class UnitFactory : IUnitFactory
    {
        //private const string unitNameSpace = "_03BarracksFactory.Models.Units.";

        public IUnit CreateUnit(string unitType)
        {
            //hardcoded solution
            //var unit = Type.GetType($"{unitNameSpace}{unitType}");
            //var instance = (IUnit)Activator.CreateInstance(unit, new object[0]);

            Assembly assembly = Assembly.GetExecutingAssembly();
            Type model = assembly.GetTypes().FirstOrDefault(t => t.Name == unitType);

            if (model == null)
            {
                throw new ArgumentException("Invalid Unit Type!");
            }

            if (!typeof(IUnit).IsAssignableFrom(model))
            {
                throw new ArgumentException($"{unitType} is not a Unit Type!");
            }

            var instance = (IUnit)Activator.CreateInstance(model);

            return instance;
        }
}
}

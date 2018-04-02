
namespace _07.InfernoInfinity.Core.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using _07.InfernoInfinity.Contracts;

    public class GemFactory : IGemFactory
    {
        public IGem Create(string typeOfGem, string clarity)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type type = assembly.GetTypes().FirstOrDefault(t => t.Name == typeOfGem);

            if (type == null)
            {
                throw new ArgumentException("Invalid Gem Type!");
            }

            if (!typeof(IGem).IsAssignableFrom(type))
            {
                throw new ArgumentException($"{typeOfGem} is not a Gem Type!");
            }

            var instance = (IGem)Activator.CreateInstance(type, clarity);

            return instance;
        }
    }
}

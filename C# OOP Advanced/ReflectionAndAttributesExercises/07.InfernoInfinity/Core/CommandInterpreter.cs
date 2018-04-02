namespace _07.InfernoInfinity.Core
{
    using System;
    using System.Linq;
    using System.Reflection;
    using _07.InfernoInfinity.Contracts;

    public class CommandInterpreter : ICommandInterpreter
    {
        private IServiceProvider serviceProvider;

        public CommandInterpreter(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public IExecutable InterpretCommand(string[] data, string commandName)
        {
            Assembly assembly = Assembly.GetCallingAssembly();
            var tipes = assembly.GetTypes();
            Type commandType = assembly.GetTypes().FirstOrDefault(t => t.Name == commandName + "Command");

            if (commandType == null)
            {
                throw new ArgumentException($"Invalid Command!");
            }

            if (!typeof(IExecutable).IsAssignableFrom(commandType))
            {
                throw new ArgumentException($"{commandName} is not a Command!");
            }

            var instance = (IExecutable)Activator.CreateInstance(commandType, serviceProvider, data);

            return instance;

        }
    }
}

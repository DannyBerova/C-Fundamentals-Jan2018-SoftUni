namespace _07.InfernoInfinity.Core
{
    using System;
    using System.Linq;
    using System.Reflection;
    using _07.InfernoInfinity.Contracts;
    using _07.InfernoInfinity.Core.Attributes;

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
            Type commandType = assembly.GetTypes().FirstOrDefault(t => t.Name == commandName + "Command");

            if (commandType == null)
            {
                throw new ArgumentException($"Invalid Command!");
            }

            if (!typeof(IExecutable).IsAssignableFrom(commandType))
            {
                throw new ArgumentException($"{commandName} is not a Command!");
            }

            var fieldsToInject = commandType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .Where(f => f.CustomAttributes.Any(ca => ca.AttributeType == typeof(InjectAttribute))).ToArray();

            var injectArgs = fieldsToInject.Select(f => this.serviceProvider.GetService(f.FieldType)).ToArray();

            object[] ctorArgs = new object[] { data }.Concat(injectArgs).ToArray();

            var instance = (IExecutable)Activator.CreateInstance(commandType, ctorArgs);

            return instance;
        }
    }
}

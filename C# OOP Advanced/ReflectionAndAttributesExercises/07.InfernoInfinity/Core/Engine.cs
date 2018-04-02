
namespace _07.InfernoInfinity.Core
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Microsoft.Extensions.DependencyInjection;
    using _07.InfernoInfinity.Contracts;

    public class Engine : IRunnable
    {
        private readonly IServiceProvider serviceProvider;

        public Engine( IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public void Run()
        {
            var interpreter = serviceProvider.GetService<ICommandInterpreter>();
            var reader = serviceProvider.GetService<IReader>();
            var writer = serviceProvider.GetService<IWriter>();

            while (true)
            {
                string input = reader.ReadLine();

                if (input == "END")
                {
                    break;
                }
                string[] data = input.Split(';');
                string commandName = data[0];
                IExecutable command = interpreter.InterpretCommand(data, commandName);

                var method = typeof(IExecutable).GetMethods().First();

                try
                {
                    string result = (string)method.Invoke(command, null);
                    if (result != string.Empty)
                    {
                        writer.WriteLine(result);
                    }
                }
                catch (TargetInvocationException tie) { }
            }
        }
    }
}

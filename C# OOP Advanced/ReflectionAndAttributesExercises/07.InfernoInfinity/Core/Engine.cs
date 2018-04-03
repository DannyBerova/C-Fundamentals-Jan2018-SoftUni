
namespace _07.InfernoInfinity.Core
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Microsoft.Extensions.DependencyInjection;
    using _07.InfernoInfinity.Contracts;

    public class Engine : IRunnable
    {
        private readonly ICommandInterpreter commandInterpreter;
        private IReader reader;
        private IWriter writer;

        public Engine( ICommandInterpreter commandInterpreter, IReader reader, IWriter writer)
        {
            this.commandInterpreter = commandInterpreter;
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {

            while (true)
            {
                string input = reader.ReadLine();

                if (input == "END")
                {
                    break;
                }
                string[] data = input.Split(';');
                string commandName = data[0];
                IExecutable command = this.commandInterpreter.InterpretCommand(data, commandName);

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

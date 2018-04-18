namespace BashSoft
{
    using Attributes;
    using Contracts;
    using IO.Commands;
    using System;
    using System.Linq;
    using System.Reflection;

    public class CommandInterpreter : IInterpreter
    {
        private IContentComparer judge;
        private IDatabase repository;
        private IDirectoryManager inputOutputManager;

        public CommandInterpreter(IContentComparer judge, IDatabase repository, IDirectoryManager inputOutputManager)
        {
            this.judge = judge;
            this.repository = repository;
            this.inputOutputManager = inputOutputManager;
        }

        public void InterpretCommand(string input)
        {
            string[] data = input.Split(' ');
            string commandName = data[0];
            try
            {
                IExecutable command = this.ParseCommand(input, commandName, data);
                command.Execute();
            }
            catch (Exception ex)
            {
                OutputWriter.DisplayException(ex.Message);
            }
        }

        private IExecutable ParseCommand(string input, string command, string[] data)
        {
            object[] parametersForConstructor = new object[]
            {
                input,
                data
            };

            Type typeOfCommand = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .First(t => t.GetCustomAttributes(typeof(AliasAttribute))
                                .Where(a => a.Equals(command))
                                .ToArray().Length > 0);

            Type typeOfInterpreter = typeof(CommandInterpreter);

            Command exe = (Command)Activator.CreateInstance(typeOfCommand, parametersForConstructor);

            FieldInfo[] fieldsOfCommand = typeOfCommand.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .ToArray();
            FieldInfo[] fieldsOfInterpreter = typeOfInterpreter.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .ToArray();

            foreach (var fieldOfCommand in fieldsOfCommand)
            {
                Attribute atrAttribute = fieldOfCommand.GetCustomAttribute(typeof(InjectAttribute));
                if (atrAttribute != null)
                {
                    if (fieldsOfInterpreter.Any(x => x.FieldType == fieldOfCommand.FieldType))
                    {
                        fieldOfCommand.SetValue(exe, fieldsOfInterpreter
                            .First(f => f.FieldType == fieldOfCommand.FieldType)
                            .GetValue(this));
                    }
                }
            }

            return exe;
        }
    }
}
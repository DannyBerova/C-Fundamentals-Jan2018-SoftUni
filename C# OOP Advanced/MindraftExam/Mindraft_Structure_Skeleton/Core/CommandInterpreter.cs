using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class CommandInterpreter : ICommandInterpreter
{
    private const string harvestercontroller = "harvesterController";
    private const string providercontroller = "providerController";

    private IHarvesterController harvesterController;
    private IProviderController providerController;

    public CommandInterpreter(IHarvesterController harvesterController, IProviderController providerController)
    {
        this.HarvesterController = harvesterController;
        this.ProviderController = providerController;
    }

    public IHarvesterController HarvesterController { get; }

    public IProviderController ProviderController { get; }

    public string ProcessCommand(IList<string> args)
    {
        string commandName = args[0];

        Type commandType = Type.GetType(commandName + Constants.CommandSuffix);

        ParameterInfo[] parametersInfo = commandType.GetConstructors().First().GetParameters();
        object[] ctorParams = new object[parametersInfo.Length];

        for (int i = 0; i < ctorParams.Length; i++)
        {
            if (parametersInfo[i].Name == harvestercontroller)
            {
                ctorParams[i] = this.HarvesterController;
            }
            else
            {
                if (parametersInfo[i].Name == providercontroller)
                {
                    ctorParams[i] = this.ProviderController;
                }
                else
                {
                    ctorParams[i] = args.Skip(1).ToList();
                }
            }
        }

        string outputResult = string.Empty;

        ICommand command = (ICommand)Activator.CreateInstance(commandType, ctorParams);

        outputResult = command.Execute();

        return outputResult;
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

public class Engine
{
    private bool isRunning;
    private NetworkManager networkManager;

    public Engine()
    {
        this.isRunning = true;
        this.networkManager = new NetworkManager();
    }

    public void Run()
    {
        while (this.isRunning)
        {
            var input = this.ReadInput();
            var commandInfo = input.Split(new char[] { '(', ')' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            this.ProcessCommand(commandInfo);
        }
    }

    private void ProcessCommand(List<string> commandInfo)
    {
        var command = commandInfo[0];
        List<string> commandArgs = new List<string>();
        if (commandInfo.Count > 1)
        {
            commandArgs = commandInfo[1]
                .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
        }

        switch (command)
        {
            case "RegisterPowerHardware":
                this.networkManager.RegisterPowerHardware(commandArgs);
                break;
            case "RegisterHeavyHardware":
                this.networkManager.RegisterHeavyHardware(commandArgs);
                break;
            case "RegisterExpressSoftware":
                this.networkManager.RegisterExpressSoftware(commandArgs);
                break;
            case "RegisterLightSoftware":
                this.networkManager.RegisterLightSoftware(commandArgs);
                break;
            case "ReleaseSoftwareComponent":
                this.networkManager.ReleaseSoftwareComponent(commandArgs);
                break;
            case "Dump":
                this.networkManager.Dump(commandArgs);
                break;
            case "Restore":
                this.networkManager.Restore(commandArgs);
                break;
            case "Destroy":
                this.networkManager.Destroy(commandArgs);
                break;
            case "Analyze":
                OutputWriter(this.networkManager.Analyze());
                break;
            case "DumpAnalyze":
                OutputWriter(this.networkManager.DumpAnalyze());
                break;
            case "System Split":
                OutputWriter(this.networkManager.SystemSplit());
                this.isRunning = false;
                break;
        }
    }

    private void OutputWriter(string result)
    {
        Console.WriteLine(result);
    }

    private string ReadInput()
    {
        return Console.ReadLine();
    }
}
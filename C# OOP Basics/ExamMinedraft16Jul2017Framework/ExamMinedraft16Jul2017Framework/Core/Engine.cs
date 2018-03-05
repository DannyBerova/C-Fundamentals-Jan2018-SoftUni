using System;
using System.Collections.Generic;
using System.Linq;

public class Engine
    {
    private bool isRunning;
    private DraftManager draftManager;

    public Engine()
    {
        this.isRunning = true;
        this.draftManager = new DraftManager();
    }

    public void Run()
    {
        while (this.isRunning)
        {
            var input = this.ReadInput();
            var commandInfo = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            this.ProcessCommand(commandInfo);
        }
    }

    private void ProcessCommand(List<string> commandInfo)
    {
        var command = commandInfo[0];
        var commandArgs = commandInfo.Skip(1).ToList();

        switch (command)
        {
            case "RegisterHarvester":
                OutputWriter(this.draftManager.RegisterHarvester(commandArgs));
                break;
            case "RegisterProvider":
                OutputWriter(this.draftManager.RegisterProvider(commandArgs));
                break;
            case "Day":
                OutputWriter(this.draftManager.Day());
                break;
            case "Mode":
                OutputWriter(this.draftManager.Mode(commandArgs));
                break;
            case "Check":
                OutputWriter(this.draftManager.Check(commandArgs));
                break;
            case "Shutdown":
                OutputWriter(this.draftManager.ShutDown());
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


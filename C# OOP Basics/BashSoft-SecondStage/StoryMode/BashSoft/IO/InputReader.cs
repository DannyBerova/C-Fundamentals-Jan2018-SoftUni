﻿using BashSoft;
using System;

public class InputReader
{
    private const string endCommand = "quit";
    private CommandInterpreter interpreter;

    public InputReader(CommandInterpreter interpreter)
    {
        this.interpreter = interpreter;
    }

    public void StartReadingCommands()
    {
        OutputWriter.WriteMessage($"{SessionData.currentPath}> ");
        string input = Console.ReadLine();
        input = input.Trim();

        while (input != endCommand)
        {
            this.interpreter.IntepredCommand(input);
            OutputWriter.WriteMessage($"{SessionData.currentPath}> ");
            input = Console.ReadLine();
            input = input.Trim();
        }
    }
}


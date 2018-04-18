using BashSoft;
using BashSoft.Contracts;
using System;

public class InputReader : IReader
{
    private const string endCommand = "quit";
    private readonly IInterpreter interpreter;

    public InputReader(IInterpreter interpreter)
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
            this.interpreter.InterpretCommand(input);
            OutputWriter.WriteMessage($"{SessionData.currentPath}> ");
            input = Console.ReadLine();
            input = input.Trim();
        }
    }
}


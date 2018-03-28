using System;
using System.Linq;

public class ComandInterpreter
{
    private bool isRunning;

    public ComandInterpreter()
    {
        this.isRunning = true;
    }

    public void Run()
    {
        var createInput = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(e => e.TrimEnd(','))
            .Skip(1)
            .ToArray();
        var stack = new Stack<string>(createInput);

        while (isRunning)
        {
            var lineArgs = Console.ReadLine().Split();
            var command = lineArgs[0];

            try
            {
                ExecuteCommand(lineArgs, command, stack);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    private void ExecuteCommand(string[] lineArgs, string command, Stack<string> stack)
    {
        switch (command)
        {
            
            case "Pop":
                stack.Pop();
                break;
            case "Push":
                var element = lineArgs.LastOrDefault();
                stack.Push(element);
                break;
            case "END":
                this.isRunning = false;
                for (int i = 0; i < 2; i++)
                {
                    foreach (var item in stack)
                    {
                        Console.WriteLine(item);
                    }
                }
                break;
        }
    }
}


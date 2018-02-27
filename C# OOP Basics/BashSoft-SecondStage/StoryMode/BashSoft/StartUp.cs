namespace BashSoft
{
    using System;
    using IO.Commands;
    using SimpleJudge;

    public class StartUp
    {
        public static void Main()
        {
            Tester tester = new Tester();
            IOManager ioManager = new IOManager();
            StudentsRepository repo = new StudentsRepository(new RepositoryFilter(), new RepositorySorter());
            CommandInterpreter currentInterpreter = new CommandInterpreter(tester, repo, ioManager);
            InputReader reader = new InputReader(currentInterpreter);

            OutputWriter.WriteMessageOnNewLine("Please enter a coomand OR type 'help' in order to get the full list of commands which are available.");
            reader.StartReadingCommands();
        }
    }
}

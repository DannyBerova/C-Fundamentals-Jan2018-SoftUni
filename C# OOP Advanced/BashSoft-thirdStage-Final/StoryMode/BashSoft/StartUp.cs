using System;

namespace BashSoft
{
    using Contracts;
    using SimpleJudge;

    public class StartUp
    {
        public static void Main()
        {
            Console.WriteLine(@"Please, enter ""help"" to recieve information about the commands available. 
    ALL COMMANDS are lowercase only! 
    See for examples in ""help"" section.");
            Console.WriteLine();

            IContentComparer tester = new Tester();
            IDirectoryManager ioManager = new IOManager();
            IDatabase repo = new StudentsRepository(new RepositorySorter(), new RepositoryFilter());

            IInterpreter currentInterpreter = new CommandInterpreter(tester, repo, ioManager);
            IReader reader = new InputReader(currentInterpreter);
            reader.StartReadingCommands();
        }
    }
}

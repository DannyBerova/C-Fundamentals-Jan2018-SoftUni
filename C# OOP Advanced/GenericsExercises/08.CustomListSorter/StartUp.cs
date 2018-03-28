using System;

namespace _08.CustomListSorter
{
    class StartUp
    {
        public static void Main()
        {
            var interpreter = new CommandInterpreter();

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                interpreter.ParseCommand(input);
            }
        }
    }
}

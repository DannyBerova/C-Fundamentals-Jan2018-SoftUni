namespace FestivalManager.Core
{
    using System.Linq;
    using System.Reflection;
    using Contracts;
    using Controllers.Contracts;
    using IO.Contracts;

    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private IFestivalController festivalCоntroller;
        private ISetController setCоntroller;

        public Engine(IReader reader, IWriter writer, IFestivalController festivalCоntroller, ISetController setCоntroller)
        {
            this.reader = reader;
            this.writer = writer;
            this.festivalCоntroller = festivalCоntroller;
            this.setCоntroller = setCоntroller;
        }

        public void Run()
        {
            string input;
            while ((input = reader.ReadLine()) != "END")
            {
                var result = this.ProcessCommand(input);
                this.writer.WriteLine(result);
            }

            var reportAfterEndCommand = this.festivalCоntroller.ProduceReport();

            this.writer.WriteLine("Results:");
            this.writer.WriteLine(reportAfterEndCommand);
        }

        public string ProcessCommand(string input)
        {
            var inputArgs = input.Split(" ".ToCharArray().First());

            var commandName = inputArgs.First();
            var cmdArgs = inputArgs.Skip(1).ToArray();

            if (commandName == "LetsRock")
            {
                var performSetReport = this.setCоntroller.PerformSets();
                return performSetReport;
            }

            var commandToInvoke = this.festivalCоntroller.GetType()
                .GetMethods()
                .FirstOrDefault(x => x.Name == commandName);

            string commandResult;
            try
            {
                commandResult = (string)commandToInvoke.Invoke(this.festivalCоntroller, new object[] { cmdArgs });
            }
            catch (TargetInvocationException tie)
            {
                commandResult = "ERROR: " + tie.InnerException.Message;
            }

            return commandResult;
        }
    }
}
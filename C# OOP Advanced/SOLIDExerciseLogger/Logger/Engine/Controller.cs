
namespace _Logger.Engine
{
    using _Logger.Factories;
    using _Logger.Interfaces;
    using _Logger.Models.LoggerModels;
    using _Logger.Models.Enums;
    using System;

    public class Controller
    {
        private FactoryAppender factoryAppender;
        private FactoryLayout factoryLayout;
        private IWriter writer;
        private IReader reader;

        public Controller(FactoryAppender factoryAppender, FactoryLayout factoryLayout, IWriter writer, IReader reader)
        {
            this.factoryAppender = factoryAppender;
            this.factoryLayout = factoryLayout;
            this.writer = writer;
            this.reader = reader;
        }

        public void Run()
        {
            writer.Write("* Enter the count of appenders to be added: ");
            var numberOfAppenders = int.Parse(reader.ReadLine());
            var appenders = new IAppender[numberOfAppenders];

            for (int i = 0; i < numberOfAppenders; i++)
            {
                writer.Write("* Enter information about the current appender: ");
                var appenderInfo = reader.ReadLine();
                var tokens = appenderInfo.Split();

                var layout = this.factoryLayout.Create(tokens[1]);
                var appender = this.factoryAppender.Create(tokens[0], layout, writer);

                if (tokens.Length == 3)
                {
                    var stringLevel = tokens[2];
                    ReportLevel level = (ReportLevel)Enum.Parse(typeof(ReportLevel), stringLevel, true);
                    appender.LevelOfThreshold = level;
                }

                appenders[i] = appender;
            }

            var logger = new Logger(appenders);

            writer.WriteLine("* In folowing format \"<REPORT LEVEL>|<time>|<message>\"");
            GetInfoOutputMessage();
            var messageInfo = reader.ReadLine();

            while (messageInfo != "END")
            {
                var args = messageInfo.Split('|');
                var reportLevel = args[0];
                var date = args[1];
                var message = args[2];

                switch (reportLevel)
                {
                    case "INFO":
                        logger.Info(date, message);
                        break;
                    case "WARNING":
                        logger.Warn(date, message);
                        break;
                    case "ERROR":
                        logger.Error(date, message);
                        break;
                    case "CRITICAL":
                        logger.Critical(date, message);
                        break;
                    case "FATAL":
                        logger.Fatal(date, message);
                        break;
                }

                GetInfoOutputMessage();

                messageInfo = reader.ReadLine();
            }

            writer.WriteLine("Logger info");
            writer.WriteLine(String.Join(Environment.NewLine, logger.GetAppenders()));
        }

        private void GetInfoOutputMessage()
        {
            writer.WriteLine("* Enter messageInfo params OR press END to recieve appenders statistics: ");
        }
    }
}
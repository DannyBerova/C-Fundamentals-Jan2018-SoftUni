namespace _Logger.Models.AppenderModels
{
    using _Logger.Models.Enums;
    using _Logger.Interfaces;
    using System.IO;

    public class FileAppender : IAppender
    {
        private readonly ILayout layout;

        private LogFile logFile;

        private int countOfMessages;

        public FileAppender(ILayout layout)
        {
            this.layout = layout;
            this.logFile = new LogFile();
            this.countOfMessages = 0;
        }

        public ReportLevel LevelOfThreshold { get; set; }

        public void Append(ReportLevel reportLevel, string date, string message)
        {
            if (this.LevelOfThreshold <= reportLevel)
            {
               
                var formattedMessage = this.layout.Formatting(reportLevel, date, message);
                this.logFile.Write(formattedMessage);

                using (var stream = new StreamWriter("Reports.txt", append: true))
                {
                    stream.WriteLine(formattedMessage);
                }

                this.countOfMessages++;
            }
        }

        public override string ToString()
        {
            var result =  $"Appender type: {this.GetType().Name}, Layout type: {this.layout.GetType().Name}, Report level: {this.LevelOfThreshold}, Messages appended: {this.countOfMessages}, File size: {this.logFile.Size}";
            return result;
        }
    }
}
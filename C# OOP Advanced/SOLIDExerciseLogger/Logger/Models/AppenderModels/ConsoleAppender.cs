namespace _Logger.Models.AppenderModels
{
    using _Logger.Models.Enums;
    using _Logger.Interfaces;
    using System;

    public class ConsoleAppender : IAppender
    {
        private ILayout layout;
        private int messagesCount;
        private IWriter writer;

        public ConsoleAppender(ILayout layout, IWriter writer)
        {
            this.layout = layout;
            this.writer = writer;
        }

        public ReportLevel LevelOfThreshold { get; set; }

        public void Append(ReportLevel reportLevel, string date, string message)
        {
            if (this.LevelOfThreshold <= reportLevel)
            {
                var formattedMsg = this.layout.Formatting(reportLevel, date, message);
                writer.WriteLine(formattedMsg);

                this.messagesCount++;

            }
        }

        public override string ToString()
        {
            return
                $"Appender type: {this.GetType().Name}, Layout type: {this.layout.GetType().Name}, Report level: {this.LevelOfThreshold}, Messages appended: {this.messagesCount}";
        }
    }
}
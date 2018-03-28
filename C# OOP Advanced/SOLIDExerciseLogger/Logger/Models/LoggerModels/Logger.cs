namespace _Logger.Models.LoggerModels
{
    using _Logger.Models.Enums;
    using _Logger.Interfaces;
    using System.Collections.Generic;

    public class Logger : ILogger
    {
        private readonly IList<IAppender> appenders;

        public Logger(params IAppender[] appenders)
        {
            this.appenders = new List<IAppender>(appenders);
        }

        public IList<IAppender> GetAppenders()
        {
            return this.appenders;
        }

        public void Info(string date, string message)
        {
            this.Append(ReportLevel.INFO, date, message);
        }

        public void Warn(string date, string message)
        {
            this.Append(ReportLevel.WARNING, date, message);
        }

        public void Error(string date, string message)
        {
            this.Append(ReportLevel.ERROR, date, message);
        }

        public void Critical(string date, string message)
        {
            this.Append(ReportLevel.CRITICAL, date, message);
        }

        public void Fatal(string date, string message)
        {
            this.Append(ReportLevel.FATAL, date, message);
        }

        private void Append(ReportLevel reportLevel, string date, string message)
        {
            foreach (var appender in this.appenders)
            {
                appender.Append(reportLevel, date, message);
            }
        }
    }
}
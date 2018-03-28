namespace _Logger.Interfaces
{
    using _Logger.Models.Enums;

    public interface IAppender
    {
        void Append(ReportLevel reportLevel, string date, string message);

        ReportLevel LevelOfThreshold { get; set; }
    }
}
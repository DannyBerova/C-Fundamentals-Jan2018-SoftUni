namespace _Logger.Interfaces
{
    using _Logger.Models.Enums;

    public interface ILayout
    {
        string Formatting(ReportLevel reportLevel, string date, string message);
    }
}
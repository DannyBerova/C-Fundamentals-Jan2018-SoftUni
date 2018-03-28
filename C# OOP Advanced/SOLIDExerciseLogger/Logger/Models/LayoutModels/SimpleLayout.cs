namespace _Logger.Models.LayoutModels
{
    using _Logger.Models.Enums;
    using _Logger.Interfaces;

    public class SimpleLayout : ILayout
    {
        public string Formatting(ReportLevel reportLevel, string date, string message)
        {
            return $"{date} - {reportLevel.ToString().ToUpper()} - {message}";
        }
    }
}
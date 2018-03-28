namespace _Logger.Models.LayoutModels
{
    using _Logger.Models.Enums;
    using _Logger.Interfaces;
    using System.Text;

    public class XmlLayout : ILayout
    {
        public string Formatting(ReportLevel reportLevel, string date, string message)
        {
            var sb = new StringBuilder();
            sb.AppendLine("<log>");
            sb.AppendLine($"    <date>{date}</date>");
            sb.AppendLine($"    <level>{reportLevel.ToString().ToUpper()}</level>");
            sb.AppendLine($"    <message>{message}</message>");
            sb.AppendLine("</log>");

            return sb.ToString().Trim();
        }
    }
}
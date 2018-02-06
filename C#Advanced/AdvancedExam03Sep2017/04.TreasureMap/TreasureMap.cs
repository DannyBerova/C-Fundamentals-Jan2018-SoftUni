using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _04.TreasureMap
{
    public class TreasureMap
    {
        public static void Main()
        {
            string pattern = @"![^!#]*?\b([A-Za-z]{4})\b[^!#]*[^\d](\d{3})-(\d{6}|\d{4})(?:[^\d!#][^!#]*)?#|#[^!#]*?\b([A-Za-z]{4})\b[^!#]*[^\d](\d{3})-(\d{6}|\d{4})(?:[^\d!#][^!#]*)?!";
            var regex = new Regex(pattern);
            var output = new StringBuilder();

            var n = int.Parse(Console.ReadLine().Trim());
            for (int line = 0; line < n; line++)
            {
                var inputLine = Console.ReadLine();

                if (regex.IsMatch(inputLine))
                {
                    var matches = regex.Matches(inputLine);
                    var mostInnerValidIndex = matches.Count / 2;
                    var validMessage = matches[mostInnerValidIndex];
                    if (validMessage.ToString().StartsWith("!"))
                    {
                        var streetName = validMessage.Groups[1].Value;
                        var streetNumber = validMessage.Groups[2].Value;
                        var pass = validMessage.Groups[3].Value;
                        output.AppendLine($"Go to str. {streetName} {streetNumber}. Secret pass: {pass}.");
                    }
                    else
                    {
                        var streetName = validMessage.Groups[4].Value;
                        var streetNumber = validMessage.Groups[5].Value;
                        var pass = validMessage.Groups[6].Value;
                        output.AppendLine($"Go to str. {streetName} {streetNumber}. Secret pass: {pass}.");
                    }
                }
            }

            Console.WriteLine(output.ToString().Trim());
        }
    }
}

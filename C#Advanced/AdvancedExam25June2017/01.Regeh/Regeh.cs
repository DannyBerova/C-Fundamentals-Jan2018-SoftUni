namespace _01.Regeh
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Text.RegularExpressions;

    public class Regeh
    {
        public static void Main()
        {
            var pattern = @"\[[^\s\[]+<([0-9]+)REGEH([0-9]+)>[^\s\]]+\]";
            var regex = new Regex(pattern);
            var output = new StringBuilder();
            var indices = new List<int>();

            var inputLine = Console.ReadLine();

            if (regex.IsMatch(inputLine))
            {
                var matches = regex.Matches(inputLine);
                var inputArray = inputLine.ToCharArray();

                for (int i = 0; i < matches.Count; i++)
                {
                    var currentMatch = matches[i];
                    indices.Add(int.Parse(currentMatch.Groups[1].Value));
                    indices.Add(int.Parse(currentMatch.Groups[2].Value));

                }

                var currentIndex = 0;
                for (int i = 0; i < indices.Count; i++)
                {
                    currentIndex += indices[i];
                    if (currentIndex > inputLine.Length - 1)
                    {
                        currentIndex %= inputLine.Length - 1;
                    }

                    output.Append(inputLine[currentIndex]);
;                }
            }

            Console.WriteLine(output);
        }
    }
}


namespace _03.CubicsMessage
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;

    public class CubicsMessage
    {
        public static void Main()
        {
            string input;

            var pattern = @"^([0-9]+)([a-zA-Z]+)([^a-zA-Z]*)$";
            var regex = new Regex(pattern);

            while ((input = Console.ReadLine()) != "Over!")
            {
                var lengthAsString = Console.ReadLine();
                int length;
                if (!int.TryParse(lengthAsString, out length))
                {
                    length = int.Parse(lengthAsString);
                }

                if (regex.IsMatch(input))
                {
                    var currentMatch = regex.Match(input);
                    var line = currentMatch.Groups[0].Value;
                    var message = currentMatch.Groups[2].Value;

                    var builder = new StringBuilder();
                    var output = new StringBuilder();

                    if (message.Length == length )
                    {
                        for (int i = 0; i < currentMatch.Length; i++)
                        {
                            if (char.IsDigit(line[i]))
                            {
                                builder.Append(line[i]);
                            }
                        }

                        for (int i = 0; i < builder.Length; i++)
                        {
                            var index = builder[i];
                            if (index - 48 < message.Length)
                            {
                                output.Append(message[index - 48]);
                            }
                            else
                            {
                                output.Append(" ");
                            }
                        }

                        Console.WriteLine($"{message} == {output}");
                    }
                    else
                    {
                        continue;
                    }
                }
            }
        }
    }
}

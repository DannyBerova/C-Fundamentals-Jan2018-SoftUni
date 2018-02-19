using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _03.Problem
{
    public class ProblemThree
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var sticked = new StringBuilder();
            var output = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                sticked.Append(Console.ReadLine());
            }

            var pattern = @"\[([^\d\[\]\{\}]*)(?<numbers>[\d]{3,})([^\[\]\{\}]*)\]|\{([^\d\[\]\{\}]*)(?<numbers>[\d]{3,})([^\[\]\{\}]*)\}";
            Regex regex = new Regex(pattern);

            MatchCollection cryptoBlocks = regex.Matches(sticked.ToString());

            for (int i = 0; i < cryptoBlocks.Count; i++)
            {
                if (cryptoBlocks[i].Groups["numbers"].Value.Length % 3 != 0)
                {
                    continue;
                }

                var currentBlock = cryptoBlocks[i].Groups["numbers"].Value;
                var numbersLength = cryptoBlocks[i].Groups["numbers"].Value.Length;
                var totalLength = cryptoBlocks[i].Length;

                while (currentBlock.Length > 0)
                {
                    var currentChar = currentBlock.Substring(0, 3);
                    output.Append((char)(int.Parse(currentChar) - totalLength));
                    currentBlock = currentBlock.Substring(3);
                }
            }

            Console.WriteLine(output);
        }
    }
}

using System;
namespace SimpleJudge
{
    using BashSoft;
    using System.IO;

    public class Tester
    {
        public void CompareContent(string userOutputPath, string expectedOutputPath)
        {
            OutputWriter.WriteMessageOnNewLine("Reading files...");

            try
            {
                string mismatchesPath = GetMismatchPath(expectedOutputPath);

                string[] actualOutputLines = File.ReadAllLines(userOutputPath);
                string[] expectedOutputLines = File.ReadAllLines(expectedOutputPath);

                bool hasMismatch;
                string[] mismatches =
                    GetLinesWithPossibleMismatches(actualOutputLines, expectedOutputLines, out hasMismatch);

                PrintOutput(mismatches, hasMismatch, mismatchesPath);
                OutputWriter.WriteMessageOnNewLine("Files read!");
            }
            catch (IOException ex)
            {
                OutputWriter.DisplayException(ex.Message);
            }
        }

        private string[] GetLinesWithPossibleMismatches(string[] actualOutputLines, string[] expectedOutputLines, out bool hasMismatch)
        {
            hasMismatch = false;
            string output = string.Empty;
            OutputWriter.WriteMessageOnNewLine("Comparing files...");

            int minOutputLines = actualOutputLines.Length;

            if (actualOutputLines.Length != expectedOutputLines.Length)
            {
                hasMismatch = true;
                minOutputLines = Math.Min(actualOutputLines.Length, expectedOutputLines.Length);
                OutputWriter.DisplayException(ExceptionMessages.ComparisonOfFilesWithDifferentSizes);
            }

            string[] mismatches = new string[minOutputLines];
            for (int i = 0; i < minOutputLines; i++)
            {
                string actualLine = actualOutputLines[i];
                string expectedLine = expectedOutputLines[i];

                if (!actualLine.Equals(expectedLine))
                {
                    output = string.Format($"Mismatch at line {i} -- expected: \"{expectedLine}\", actual: \"{actualLine}\"");
                    output += Environment.NewLine;
                    hasMismatch = true;
                }
                else
                {
                    output = actualLine;
                    output += Environment.NewLine;
                }

                mismatches[i] = output;
            }

            return mismatches;
        }

        private void PrintOutput(string[] mismatches, bool hasMismatch, string mismatchesPath)
        {
            if (hasMismatch)
            {
                foreach (var line in mismatches)
                {
                    OutputWriter.WriteMessageOnNewLine(line);
                }
                File.WriteAllLines(mismatchesPath, mismatches);
                return;
            }

            OutputWriter.WriteMessageOnNewLine("Files are identical. There are no mismatches.");
        }
        
        private string GetMismatchPath(string expectedOutputPath)
        {
            int indexOf = expectedOutputPath.LastIndexOf('\\');
            string direcoryPath = expectedOutputPath.Substring(0, indexOf);
            string finalPath = direcoryPath + @"\Mismatches.txt";

            return finalPath;
        }
    }
}

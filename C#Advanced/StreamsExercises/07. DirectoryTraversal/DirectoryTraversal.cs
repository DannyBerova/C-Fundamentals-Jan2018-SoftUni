namespace _07._DirectoryTraversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.IO.Compression;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            var files = Directory.GetFiles(input);

            var filesGroupedByExt = new Dictionary<string, List<KeyValuePair<string, double>>>();

            foreach (var file in files)
            {
                int lastSlashIndex = file.LastIndexOf('\\');
                string fileName = file.Substring(lastSlashIndex);

                string extension = fileName.Substring(fileName.LastIndexOf('.'));

                double size = new FileInfo(file).Length / (double)1024;

                if (!filesGroupedByExt.ContainsKey(extension))
                {
                    filesGroupedByExt.Add(extension, new List<KeyValuePair<string, double>>());
                }
                filesGroupedByExt[extension].Add(new KeyValuePair<string, double>(fileName, size));
            }

            var desktopFolder = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            var fullFileName = $"{desktopFolder}\\report.txt";

            using (var writer = new StreamWriter(fullFileName))
            {
                filesGroupedByExt = filesGroupedByExt
                    .OrderByDescending(x => x.Value.Count)
                    .ThenBy(x => x.Key)
                    .ToDictionary(x => x.Key, y => y.Value);

                foreach (var keyValuePair in filesGroupedByExt)
                {
                    writer.WriteLine(keyValuePair.Key);
                    foreach (var valuePair in keyValuePair.Value)
                    {
                        writer.WriteLine($"--{valuePair.Key} - {valuePair.Value:0.###}kb");
                    }
                }
            }
        }
    }
}


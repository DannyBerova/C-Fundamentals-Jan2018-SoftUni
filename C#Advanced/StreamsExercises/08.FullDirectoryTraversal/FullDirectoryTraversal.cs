namespace _08.FullDirectoryTraversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    class FullDirectoryTraversal
    {
        private static Dictionary<string, List<KeyValuePair<string, double>>> filesGroupedByExt 
            = new Dictionary<string, List<KeyValuePair<string, double>>>();

        public static void Main()
        {
            string inputDir = Console.ReadLine();
            List<string> filesInDir = new List<string>();

            filesInDir.Add(inputDir);
            filesInDir.AddRange(Directory.GetDirectories(inputDir, ".", SearchOption.AllDirectories)
                            .ToList());

            foreach (var path in filesInDir)
            {
                TraverseDirectory(path);
            }

            Report();
        }

        private static void Report()
        {
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
                    foreach (var valuePair in keyValuePair.Value.OrderBy(x => x.Key))
                    {
                        writer.WriteLine($"--{valuePair.Key} - {valuePair.Value:0.###}kb");
                    }
                }
            }
        }

        private static void TraverseDirectory(string dir)
        {
            var files = Directory.GetFiles(dir);

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
        }
    }
}

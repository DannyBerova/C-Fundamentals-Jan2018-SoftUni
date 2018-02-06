namespace _05.SlicingFile
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class SlicingFile
    {
        private const int bufferSize = 4096;
       
        public static void Main()
        {
            Console.Write(@"Enter the path of the file to be sliced OR ""1"" to use the sample file: ");
            string sourceFile = Console.ReadLine();

            if (sourceFile == "1")
            {
                sourceFile = @"..\Files\sliceMe.mp4";
            }


            Console.Write("Enter the number of parts to slice: ");
            int parts = int.Parse(Console.ReadLine());

            Console.Write(@"Enter directory path for the assembled file OR PRESS ENTER to use the current directory: ");
            string destinationDirectory = Console.ReadLine();

            if (destinationDirectory == string.Empty)
            {
                destinationDirectory = "./";
            }

            Slice(sourceFile, destinationDirectory, parts);

            string extension = sourceFile.Substring(sourceFile.LastIndexOf('.') + 1);
            var files = new List<string>();

            for (int i = 0; i < parts; i++)
            {
                files.Add($"Part-{i}.{extension}");
            }

            Assemble(files, destinationDirectory);
        }

        static void Slice(string sourceFile, string destinationDirectory, int parts)
        {
            using (FileStream reader = new FileStream(sourceFile, FileMode.Open))
            {
                string extension = sourceFile.Substring(sourceFile.LastIndexOf('.') + 1);

                long pieceSize = (long)Math.Ceiling((double)reader.Length / parts);

                for (int i = 0; i < parts; i++)
                {
                    long currentPieceSize = 0;

                    if (destinationDirectory == string.Empty)
                    {
                        destinationDirectory = "./";
                    }
                    string currentPart = $"{destinationDirectory}/Part-{i}.{extension}";

                    using (FileStream writer = new FileStream(currentPart, FileMode.Create))
                    {
                        var buffer = new byte[bufferSize];

                        while (reader.Read(buffer, 0, bufferSize) == bufferSize)
                        {
                            writer.Write(buffer, 0, bufferSize);
                            currentPieceSize += bufferSize;
                            if (currentPieceSize >= pieceSize)
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }

        static void Assemble(List<string> files, string destinationDirectory)
        {
            string extension = files[0].Substring(files[0].LastIndexOf('.') + 1);

            if (destinationDirectory == string.Empty)
            {
                destinationDirectory = "./";
            }

            string assembledFile = $"{destinationDirectory}Assembled.{extension}";

            using (FileStream writer = new FileStream(assembledFile, FileMode.Create))
            {
                var buffer = new byte[bufferSize];

                foreach (var file in files)
                {
                    using (var reader = new FileStream(file, FileMode.Open))
                    {
                        while (reader.Read(buffer, 0, bufferSize) == bufferSize)
                        {
                            writer.Write(buffer, 0, bufferSize);
                        }
                    }
                }
            }
        }

    }
}
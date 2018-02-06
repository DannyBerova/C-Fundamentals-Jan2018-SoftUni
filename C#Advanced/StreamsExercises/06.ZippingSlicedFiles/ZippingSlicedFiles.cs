
namespace _06.ZippingSlicedFiles
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.IO.Compression;

    public class ZippingSlicedFiles
    {
        private const int bufferSize = 4096;

        public static void Main()
        {
            Console.Write(@"Enter the path to the file to be sliced and compressed OR ""1"" to use the sample file: ");
            string sourceFile = Console.ReadLine();

            if (sourceFile == "1")
            {
                sourceFile = @"..\Files\sliceMe.mp4";
            }


            Console.Write("Enter the number of parts to slice: ");
            int parts = int.Parse(Console.ReadLine());

            Console.Write(@"Enter directory path for the decompressed and assembled file OR PRESS ENTER to use the current directory: ");
            string destinationDirectory = Console.ReadLine();

            if (destinationDirectory == string.Empty)
            {
                destinationDirectory = "./";
            }

            Zip(sourceFile, destinationDirectory, parts);

            string extension = sourceFile.Substring(sourceFile.LastIndexOf('.') + 1);
            var files = new List<string>();

            for (int i = 0; i < parts; i++)
            {
                files.Add($"Part-{i}.{extension}.gz");
            }

            Assemble(files, destinationDirectory);
        }

        static void Assemble(List<string> files, string destinationDirectory)
        {
            string trimed = files[0].Substring(0, files[0].Length - 3);
            string extension = trimed.Substring(trimed.LastIndexOf('.') + 1);

            if (destinationDirectory == string.Empty)
            {
                destinationDirectory = "./";
            }

            string assembledFile = $"{destinationDirectory}Assembled.{extension}";

            using (FileStream output = new FileStream(assembledFile, FileMode.OpenOrCreate, FileAccess.Write))
            {
                foreach (var filePath in files)
                {
                    byte[] buffer = new byte[1024];
                    int bytesRead = 0;

                    using (GZipStream writer = new GZipStream(new FileStream(filePath, FileMode.Open, FileAccess.Read), CompressionMode.Decompress, false))
                    {
                        while ((bytesRead = writer.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            output.Write(buffer, 0, bytesRead);
                        }
                    }
                }

                Console.WriteLine("Decompressed: {0} ({1} MB)", output.Name, output.Length / 1024f / 1024f);
            }

        }

        static void Zip(string sourceFile, string destinationDirectory, int parts)
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
                    string currentPart = $"{destinationDirectory}/Part-{i}.{extension}.gz";

                    using (GZipStream writer = new GZipStream(new FileStream(currentPart, FileMode.Create), CompressionLevel.Optimal))
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
    }
}

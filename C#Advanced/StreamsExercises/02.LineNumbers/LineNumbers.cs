namespace _02.LineNumbers
{
    using System.IO;

    public class LineNumbers
    {
        public static void Main()
        {
            using (var reader = new StreamReader(@"..\Files\text.txt"))
            {
                using (var writer = new StreamWriter("output.txt"))
                {
                    int lineNumbers = 0;

                    while (true)
                    {
                        string line = reader.ReadLine();

                        if (line == null)
                        {
                            break;
                        }

                        writer.WriteLine($"Line {++lineNumbers}: {line}");
                    }
                }
            }
        }
    }
}
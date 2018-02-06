namespace _02.Cubic_sRube
{
    using System;
    using System.Linq;

    public class CubicSRube
    {
        public static void Main()
        {
            var n = long.Parse(Console.ReadLine());

            var rube = new long[n, n, n];
            long sumTotal = 0;
            long changedSellsCounter = 0;
            
            var inputLine = Console.ReadLine();

            while (inputLine != "Analyze")
            {
                var inputTokens = inputLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var rowIndex = long.Parse(inputTokens[0]);
                var colIndex = long.Parse(inputTokens[1]);
                var depthIndex = long.Parse(inputTokens[2]);
                var particles = long.Parse(inputTokens[3]);

                if (rowIndex < n && colIndex < n && depthIndex < n && rowIndex >= 0 && colIndex >= 0 && depthIndex >= 0 && particles != 0)
                {
                    if (rube[rowIndex, colIndex, depthIndex] == 0)
                    {
                        rube[rowIndex, colIndex, depthIndex] = particles;
                        changedSellsCounter++;
                        sumTotal += particles;
                    }

                }

                inputLine = Console.ReadLine();
            }

            Console.WriteLine(sumTotal);
            Console.WriteLine(rube.LongLength - changedSellsCounter);
        }
    }
}

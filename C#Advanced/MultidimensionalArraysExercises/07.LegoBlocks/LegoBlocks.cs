using System;
using System.Linq;

namespace _07.LegoBlocks
{
    public class LegoBlocks
    {
        public static void Main()
        {
            var rows = int.Parse(Console.ReadLine());
            var matrixA = GetMatrix(rows);
            var matrixB = GetMatrix(rows);
            var totalCount = GetElementsCount(matrixA, matrixB);

            if (totalCount > 0)
            {
                Console.WriteLine($"The total number of cells is: {totalCount}");
            }
            else
            {
                PrintMatrix(GetJoinedMatrix(matrixA, matrixB));
            }
        }

        private static int[][] GetJoinedMatrix(int[][] matrixA, int[][] matrixB)
        {
            var rows = matrixA.Length;
            var joinedMatrix = new int[rows][];

            for (int row = 0; row < rows; row++)
            {
                joinedMatrix[row] = matrixA[row].Concat(matrixB[row].Reverse()).ToArray();
            }

            return joinedMatrix;
        }

        private static long GetElementsCount(int[][] matrixA, int[][] matrixB)
        {
            long firstRowCount = matrixA[0].Length + matrixB[0].Length;
            long totalCount = firstRowCount;
            bool isValidBlock = true;

            for (int row = 1; row < matrixA.Length; row++)
            {
                var currentRowCount = matrixA[row].Length + matrixB[row].Length;
                totalCount += currentRowCount;

                if (currentRowCount != firstRowCount)
                {
                    isValidBlock = false;
                }
            }

            if (isValidBlock)
            {
                return 0;
            }

            return totalCount;
        }

        private static int[][] GetMatrix(int rows)
        {
            var matrix = new int[rows][];

            for (int row = 0; row < rows; row++)
            {
                matrix[row] = Console.ReadLine()
                    .Trim()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }

            return matrix;
        }

        private static void PrintMatrix(int[][] matrix)
        {
            foreach (var row in matrix)
            {
                Console.WriteLine($"[{string.Join(", ", row)}]");
            }
        }
    }
}

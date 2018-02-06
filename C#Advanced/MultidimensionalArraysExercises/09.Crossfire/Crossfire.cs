using System;
using System.Linq;

namespace _09.Crossfire
{
    public class Crossfire
    {
        public static void Main()
        {
            var matrixSize = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var rows = matrixSize[0];
            var cols = matrixSize[1];

            var matrix = new int[rows][];
            int counter = 1;

            for (int rowIndex = 0; rowIndex < rows; rowIndex++)
            {
                matrix[rowIndex] = new int[cols];
                for (int colIndex = 0; colIndex < matrix[0].Length; colIndex++)
                {
                    matrix[rowIndex][colIndex] = counter;
                    counter++;
                }
            }

            string commandArgs = Console.ReadLine();

            while (commandArgs != "Nuke it from orbit")
            {
                var tokens = commandArgs
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                var row = tokens[0];
                var column = tokens[1];
                var radius = tokens[2];

                for (int rowIndex = row - radius; rowIndex <= row + radius; rowIndex++)
                {
                    if (IsInMatrixBoundaries(rowIndex, column, matrix))
                    {
                        matrix[rowIndex][column] = 0;
                    }
                }

                for (int colIndex = column - radius; colIndex <= column + radius; colIndex++)
                {
                    if (IsInMatrixBoundaries(row, colIndex, matrix))
                    {
                        matrix[row][colIndex] = 0;
                    }
                }

                //remove empty elements
                for (int rowIndex = 0; rowIndex < matrix.Length; rowIndex++)
                {
                    var index = matrix[rowIndex].Where(i => i != 0).Count();
                    var currentRow = new int[index];
                    var insertIndex = 0;
                    for (int colIndex = 0; colIndex < matrix[rowIndex].Length; colIndex++)
                    {
                        if (matrix[rowIndex][colIndex] != 0)
                        {
                            currentRow[insertIndex] = matrix[rowIndex][colIndex];
                            insertIndex++;
                        }
                    }
                    matrix[rowIndex] = currentRow;
                }

                //remove empty rows
                for (int rowIndex = 0; rowIndex < matrix.Length; rowIndex++)
                {
                    if (matrix[rowIndex].Length <= 0)
                    {
                        matrix = matrix.Take(rowIndex).Concat(matrix.Skip(rowIndex + 1)).ToArray();
                        rowIndex--;
                    }
                }

                commandArgs = Console.ReadLine();
            }

            foreach (var r in matrix)
            {
                Console.WriteLine(string.Join(" ", r));
            }
        }

        private static bool IsInMatrixBoundaries(int row, int col, int[][] matrix)
        {
            return row >= 0 && col >= 0 && row < matrix.Length && col < matrix[row].Length;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.TargetPractice
{
    public class TargetPractice
    {
        private const char destroyedElement = ' ';

        public static void Main()
        {
            var matrix = GetMatrix();
            ShootMatrix(matrix);
            PrintMatrix(CollapseMatrix(matrix));
        }

        private static char[][] CollapseMatrix(char[][] matrix)
        {
            CollapseMatrixCols(matrix);
            return RemoveEmptyRowsFromMatrix(matrix);
        }

        private static char[][] RemoveEmptyRowsFromMatrix(char[][] matrix)
        {
            var resultingMatrix = new List<char[]>();

            for (int row = 0; row < matrix.Count(); row++)
            {
                if (matrix[row].Any(x => x != destroyedElement))
                {
                    resultingMatrix.Add(matrix[row]);
                }
            }

            return resultingMatrix.ToArray();
        }

        private static void CollapseMatrixCols(char[][] matrix)
        {
            var rows = matrix.Count();
            var cols = matrix[0].Count();

            for (int col = 0; col < cols; col++)
            {
                var colRemainingElements = new List<char>();

                for (int row = 0; row < rows; row++)
                {
                    if (matrix[row][col] != destroyedElement)
                    {
                        colRemainingElements.Add(matrix[row][col]);
                    }
                }

                colRemainingElements.Reverse();

                if (colRemainingElements.Count == rows)
                {
                    continue;
                }
                var index = 0;

                for (int row = rows - 1; row >= 0; row--)
                {
                    if (index < colRemainingElements.Count)
                    {
                        matrix[row][col] = colRemainingElements[index++];
                    }

                    else
                    {
                        matrix[row][col] = destroyedElement;
                    }
                }
            }
        }

        private static void ShootMatrix(char[][] matrix)
        {
            var shotParams = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var impactRow = shotParams[0];
            var impactCol = shotParams[1];
            var radius = shotParams[2];

            for (int row = impactRow - radius; row <= impactRow + radius; row++)
            {
                for (int col = impactCol - radius; col <= impactCol + radius; col++)
                {
                    if (!isWithinMatrix(matrix, row, col))
                    {
                        continue;
                    }

                    if (isWithinShootingRange(matrix, impactRow, impactCol, radius, row, col))
                    {
                        matrix[row][col] = destroyedElement;
                    }
                }
            }
        }

        private static bool isWithinMatrix(char[][] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.Length && col >= 0 && col < matrix[0].Length;
        }

        private static bool isWithinShootingRange(char[][] matrix, int impactRow, int impactCol, int radius, int row, int col)
        {
            var distance = Math.Sqrt(Math.Pow(impactRow - row, 2) + Math.Pow(impactCol - col, 2));
            return distance <= radius;
        }

        public static void PrintMatrix(char[][] matrix)
        {
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join("", row));
            }
        }

        private static char[][] GetMatrix()
        {
            var size = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var pattern = Console.ReadLine().Trim();
            int rows = size[0];
            int cols = size[1];
            var matrix = new char[rows][];
            var isReverseOrder = 1;
            var currentPattern = pattern;

            for (int row = rows - 1; row >= 0; row--)
            {
                while (currentPattern.Length < cols)
                {
                    currentPattern += pattern;
                }
                matrix[row] = currentPattern.Take(cols).ToArray();

                if (isReverseOrder == 1)
                {
                    matrix[row] = matrix[row].Reverse().ToArray();
                }
                currentPattern = currentPattern.Substring(cols);
                isReverseOrder *= -1;
            }

            return matrix;
        }
    }
}
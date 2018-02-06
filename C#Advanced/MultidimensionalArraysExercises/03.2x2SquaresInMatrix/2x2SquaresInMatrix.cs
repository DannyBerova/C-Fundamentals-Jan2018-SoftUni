using System;
using System.Linq;

namespace _03._2x2SquaresInMatrix
{
    public class TwoXTwoSquaresInMatrix
    {
        public static void Main()
        {
            var size = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

            var rows = size[0];
            var matrix = new char[rows][];

            for (int row = 0; row < rows; row++)
            {
                matrix[row] = Console.ReadLine()
                        .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(x => x[0])
                        .ToArray();
            }

            var rowsLength = matrix.Length;
            var colsLength = matrix[0].Length;
            int squaresCount = 0;

            for (int row = 0; row < rowsLength - 1; row++)
            {
                for (int col = 0; col < colsLength - 1; col++)
                {
                    if (IsSquareEqual(matrix, row, col))
                    {
                        squaresCount++;
                    }
                }
            }

            Console.WriteLine(squaresCount);
        }

        private static bool IsSquareEqual(char[][] matrix, int row, int col)
        {
            var cell = matrix[row][col];

            return cell == matrix[row][col + 1] && cell 
                        == matrix[row + 1][col] && cell 
                        == matrix[row + 1][col + 1];
        }
    }
}

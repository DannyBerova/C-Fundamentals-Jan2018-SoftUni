using System;
using System.Linq;

namespace _05.RubikSMatrix
{
    public class RubikSMatrix
    {
        public static void Main()
        {
            int[] rowCols = Console.ReadLine()
                .Trim()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[,] matrix = new int[rowCols[0], rowCols[1]];

            FillMatrix(matrix);
            PerformCommand(matrix);
            SwapMatrix(matrix);
        }

        private static void FillMatrix(int[,] matrix)
        {
            int count = 1;
            for (int rowIndex = 0; rowIndex < matrix.GetLength(0); rowIndex++)
            {
                for (int colIndex = 0; colIndex < matrix.GetLength(1); colIndex++)
                {
                    matrix[rowIndex, colIndex] = count;
                    count++;
                }
            }
        }

        private static int[] FindIndex(int[,] matrix, int target)
        {
            int[] coordinates = new int[2];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (target == matrix[row, col])
                    {
                        coordinates[0] = row;
                        coordinates[1] = col;
                        break;
                    }
                }
            }

            return coordinates;
        }

        private static void PerformCommand(int[,] matrix)
        {
            int cmdCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < cmdCount; i++)
            {
                string[] inputCmd = Console.ReadLine().Split(' ');
                int rowOrCol = int.Parse(inputCmd[0]);
                string cmd = inputCmd[1];
                int moves = int.Parse(inputCmd[2]);

                switch (cmd)
                {
                    case "up":
                        for (int j = 0; j < moves % matrix.GetLength(0); j++)
                        {
                            MoveUp(matrix, rowOrCol);
                        }

                        break;

                    case "down":
                        for (int j = 0; j < moves % matrix.GetLength(0); j++)
                        {
                            MoveDown(matrix, rowOrCol);
                        }

                        break;

                    case "left":
                        for (int j = 0; j < moves % matrix.GetLength(1); j++)
                        {
                            MoveLeft(matrix, rowOrCol);
                        }

                        break;

                    case "right":
                        for (int j = 0; j < moves % matrix.GetLength(1); j++)
                        {
                            MoveRight(matrix, rowOrCol);
                        }

                        break;
                }
            }
        }

        private static void MoveRight(int[,] matrix, int row)
        {
            int temp = matrix[row, matrix.GetLength(1) - 1];

            for (int col = matrix.GetLength(1) - 1; col > 0; col--)
            {
                matrix[row, col] = matrix[row, col - 1];
            }

            matrix[row, 0] = temp;
        }

        private static void MoveLeft(int[,] matrix, int row)
        {
            int temp = matrix[row, 0];

            for (int col = 0; col < matrix.GetLength(1) - 1; col++)
            {
                matrix[row, col] = matrix[row, col + 1];
            }

            matrix[row, matrix.GetLength(1) - 1] = temp;
        }

        private static void MoveUp(int[,] matrix, int col)
        {
            int temp = matrix[0, col];

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                matrix[row, col] = matrix[row + 1, col];
            }

            matrix[matrix.GetLength(0) - 1, col] = temp;
        }

        private static void MoveDown(int[,] matrix, int col)
        {
            int temp = matrix[matrix.GetLength(0) - 1, col];

            for (int row = matrix.GetLength(0) - 1; row > 0; row--)
            {
                matrix[row, col] = matrix[row - 1, col];
            }

            matrix[0, col] = temp;
        }

        private static void SwapMatrix(int[,] matrix)
        {
            int count = 1;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == count)
                    {
                        Console.WriteLine("No swap required");
                    }
                    else
                    {
                        int[] swapIndex = FindIndex(matrix, count);
                        Console.WriteLine($"Swap ({row}, {col}) with ({swapIndex[0]}, {swapIndex[1]})");
                        int temp = matrix[row, col];
                        matrix[row, col] = matrix[swapIndex[0], swapIndex[1]];
                        matrix[swapIndex[0], swapIndex[1]] = temp;
                    }

                    count++;
                }
            }
        }
    }
}
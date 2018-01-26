using System;
using System.Linq;

namespace _02.SquareWithMaxSum
{
    public class SquareWithMaxSum
    {
        public static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                 .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();

            int[,] matrix = new int[dimensions[0], dimensions[1]];

            for (int rows = 0; rows < dimensions[0]; rows++)
            {
                var rowIncomes = Console.ReadLine()
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int cols = 0; cols < dimensions[1]; cols++)
                {
                    matrix[rows, cols] = rowIncomes[cols];
                }
            }

           // int sum = 0;
            int maxSum = int.MinValue;
            int rowIndex = 0;
            int colIndex = 0;

            for (int rows = 0; rows < matrix.GetLength(0) - 1; rows++)
            {
                for (int cols = 0; cols < matrix.GetLength(1) - 1; cols++)
                {
                    var currentSum = matrix[rows, cols] + matrix[rows, cols + 1]
                                     + matrix[rows + 1, cols] + matrix[rows + 1, cols + 1];

                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        rowIndex = rows;
                        colIndex = cols;
                    }
                }
            }

            Console.WriteLine($"{matrix[rowIndex, colIndex]} {matrix[rowIndex, colIndex + 1]}");
            Console.WriteLine($"{matrix[rowIndex + 1, colIndex]} {matrix[rowIndex + 1, colIndex + 1]}");
            Console.WriteLine(maxSum);
        }
    }
}

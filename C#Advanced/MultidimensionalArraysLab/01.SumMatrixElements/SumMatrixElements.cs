using System;
using System.Linq;

namespace _01.SumMatrixElements
{
    public class SumMatrixElements
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

            int sum = 0;
            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    sum += matrix[rows, cols];
                }
            }

            Console.WriteLine(dimensions[0]);
            Console.WriteLine(dimensions[1]);
            Console.WriteLine(sum);
        }
    }
}

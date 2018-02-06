using System;
using System.Linq;

namespace _02.DiagonalDifference
{
    public class DiagonalDifference
    {
        public static void Main()
        {
            var size = int.Parse(Console.ReadLine());
            var matrix = new int[size][];

            for (int row = 0; row < size; row++)
            {
                matrix[row] = Console.ReadLine()
                        .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();              
            }

            long primaryDiagonalSum = 0;
            long secondaryDiagonalSum = 0;

            for (int r = 0; r < matrix.Length; r++)
            {
                primaryDiagonalSum += matrix[r][r];
                secondaryDiagonalSum += matrix[r][matrix.Length - 1 - r];
            }

            long difference = Math.Abs(primaryDiagonalSum - secondaryDiagonalSum);
            Console.WriteLine(difference);
        }
    }
}

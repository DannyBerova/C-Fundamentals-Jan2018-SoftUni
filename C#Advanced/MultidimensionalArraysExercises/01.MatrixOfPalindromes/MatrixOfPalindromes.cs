using System;
using System.Linq;

namespace _01.MatrixOfPalindromes
{
    public class MatrixOfPalindromes
    {
        public static void Main()
        {
            var dimensions = Console.ReadLine()
                   .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                   .Select(int.Parse)
                   .ToArray();

            var rows = dimensions[0];
            var cols = dimensions[1];

            string[][] matrix = new string[rows][];
            char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = new string[cols];
                for (int colsIndex = 0; colsIndex < cols; colsIndex++)
                {
                    string currentString = $"{alphabet[row]}{alphabet[row + colsIndex]}{alphabet[row]}";
                    matrix[row][colsIndex] = currentString;
                }
            }

            for (int i = 0; i < matrix.Length; i++)
            {
                Console.WriteLine(string.Join(" ", matrix[i]));
            }
        }
    }
}

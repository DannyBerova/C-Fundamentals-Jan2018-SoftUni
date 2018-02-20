using System;
using System.Linq;

namespace _02.Problem
{
    public class ProblemTwo
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            char[][] matrix = new char[n][];
            var rowOfSam = 0;
            var colOfSam = 0;
            var rowOfNikoladze = 0;
            var colOfNikoladze = 0;

            for (int rowMtr = 0; rowMtr < n; rowMtr++)
            {
                var currentInput = Console.ReadLine().ToCharArray();
                matrix[rowMtr] = currentInput;
                GetSamAndNikoladzePosition(matrix, ref rowOfSam, ref colOfSam, ref rowOfNikoladze, ref colOfNikoladze, rowMtr);
            }
            var commands = Console.ReadLine().ToCharArray();
            var positionOfSam = new int[] { rowOfSam, colOfSam };

            for (int i = 0; i < commands.Length; i++)
            {
                EnemiesMove(matrix);

                var command = commands[i];
                var current = matrix[positionOfSam[0]].ToList();

                if (current.Contains('b'))
                {
                    if (current.IndexOf('b') < current.IndexOf('S'))
                    {
                        CheckIsSamDead(matrix, positionOfSam);
                        break;
                    }
                }

                if (current.Contains('d'))
                {
                    if (current.IndexOf('d') > current.IndexOf('S'))
                    {
                        CheckIsSamDead(matrix, positionOfSam);
                        break;
                    }
                }
                positionOfSam = SamMoves(matrix, positionOfSam, command);

                if (positionOfSam[0] == rowOfNikoladze)
                {
                    matrix[rowOfNikoladze][colOfNikoladze] = 'X';
                    Console.WriteLine("Nikoladze killed!");
                    break;
                }
            }

            PrintMatrix(matrix);
        }

        private static void GetSamAndNikoladzePosition(char[][] matrix, ref int rowOfSam, ref int colOfSam, ref int rowOfNikoladze, ref int colOfNikoladze, int rowMtr)
        {
            for (int colMtr = 0; colMtr < matrix[rowMtr].Length; colMtr++)
            {
                if (matrix[rowMtr][colMtr] == 'S')
                {
                    rowOfSam = rowMtr;
                    colOfSam = colMtr;
                }
                if (matrix[rowMtr][colMtr] == 'N')
                {
                    rowOfNikoladze = rowMtr;
                    colOfNikoladze = colMtr;
                }
            }
        }

        private static void CheckIsSamDead(char[][] matrix, int[] positionOfSam)
        {
            matrix[positionOfSam[0]][positionOfSam[1]] = 'X';
            Console.WriteLine($"Sam died at {positionOfSam[0]}, {positionOfSam[1]}");
        }

        private static void EnemiesMove(char[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                var currentRow = matrix[i].ToArray();

                if (currentRow.Contains('b'))
                {
                    var bIndex = Array.IndexOf(currentRow, 'b');
                    if (bIndex < currentRow.Length - 1)
                    {
                        matrix[i][bIndex + 1] = 'b';
                        matrix[i][bIndex] = '.';
                    }
                    if (bIndex == currentRow.Length - 1)
                    {
                        matrix[i][bIndex] = 'd';
                    }

                }
                if (currentRow.Contains('d'))
                {
                    var dIndex = Array.IndexOf(currentRow, 'd');
                    if (dIndex >= 1)
                    {
                        matrix[i][dIndex - 1] = 'd';
                        matrix[i][dIndex] = '.';
                    }
                    if (dIndex == 0)
                    {
                        matrix[i][dIndex] = 'b';
                    }
                }
            }
        }

        private static int[] SamMoves(char[][] matrix, int[] position, char command)
        {
            var rowOfSam = position[0];
            var colOfSam = position[1];
            switch (command)
            {
                case 'U':
                    matrix[rowOfSam][colOfSam] = '.';
                    matrix[rowOfSam - 1][colOfSam] = 'S';
                    rowOfSam--;
                    break;
                case 'D':
                    matrix[rowOfSam][colOfSam] = '.';
                    matrix[rowOfSam + 1][colOfSam] = 'S';
                    rowOfSam++;
                    break;
                case 'L':
                    matrix[rowOfSam][colOfSam] = '.';
                    matrix[rowOfSam][colOfSam - 1] = 'S';
                    colOfSam--;
                    break;
                case 'R':
                    matrix[rowOfSam][colOfSam] = '.';
                    matrix[rowOfSam][colOfSam + 1] = 'S';
                    colOfSam++;
                    break;
                case 'W':
                    break;
            }

            position[0] = rowOfSam;
            position[1] = colOfSam;
            return position;
        }

        private static void PrintMatrix(char[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write(matrix[row][col]);
                }
                Console.WriteLine();
            }
        }
    }
}

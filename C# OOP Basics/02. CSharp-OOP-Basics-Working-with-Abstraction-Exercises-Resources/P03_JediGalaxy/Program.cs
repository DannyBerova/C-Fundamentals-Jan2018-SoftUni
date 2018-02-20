using System;
using System.Linq;

namespace P03_JediGalaxy
{
    class Program
    {
        static void Main()
        {
            int row, col;
            ParseInputArgs(out row, out col);

            int[,] matrix = new int[row, col];

            FillMatrix(row, col, matrix);

            string command = Console.ReadLine();
            long sum = 0;

            while (command != "Let the Force be with you")
            {
                int ivoRow, ivoCol;
                ParseInputArgs(command, out ivoRow, out ivoCol);

                int evilRow, evilCol;
                ParseInputArgs(out evilRow, out evilCol);

                EvilDestructionOfStars(matrix, ref evilRow, ref evilCol);

                IvoCollectsStars(matrix, ref sum, ref ivoRow, ref ivoCol);

                command = Console.ReadLine();
            }

            Console.WriteLine(sum);

        }

        private static void ParseInputArgs(string command, out int ivoRow, out int ivoCol)
        {
            int[] ivoPosition = command.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            ivoRow = ivoPosition[0];
            ivoCol = ivoPosition[1];
        }

        private static void ParseInputArgs(out int row, out int col)
        {
            int[] dimensions = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            row = dimensions[0];
            col = dimensions[1];
        }

        private static void IvoCollectsStars(int[,] matrix, ref long sum, ref int ivoRow, ref int ivoCol)
        {
            while (ivoRow >= 0 && ivoCol < matrix.GetLength(1))
            {
                if (ivoRow >= 0 && ivoRow < matrix.GetLength(0) && ivoCol >= 0 && ivoCol < matrix.GetLength(1))
                {
                    sum += matrix[ivoRow, ivoCol];
                }

                ivoCol++;
                ivoRow--;
            }
        }

        private static void EvilDestructionOfStars(int[,] matrix, ref int evilRow, ref int evilCol)
        {
            while (evilRow >= 0 && evilCol >= 0)
            {
                if (evilRow >= 0 && evilRow < matrix.GetLength(0) && evilCol >= 0 && evilCol < matrix.GetLength(1))
                {
                    matrix[evilRow, evilCol] = 0;
                }
                evilRow--;
                evilCol--;
            }
        }

        private static void FillMatrix(int x, int y, int[,] matrix)
        {
            int value = 0;
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    matrix[i, j] = value++;
                }
            }
        }
    }
}

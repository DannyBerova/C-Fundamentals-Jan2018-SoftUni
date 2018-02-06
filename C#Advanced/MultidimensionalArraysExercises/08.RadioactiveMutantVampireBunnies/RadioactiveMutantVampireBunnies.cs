using System;
using System.Linq;

namespace _08.RadioactiveMutantVampireBunnies
{
    public class RadioactiveMutantVampireBunnies
    {
        private const char player = 'P';
        private const char bunny = 'B';
        private const char newBunny = 'b';
        private const char vacantPosition = '.';

        private enum Status { alive, won, dead }
        private static Status playerStatus;
        private static int[] playerPosition;

        public static void Main()
        {
            var matrix = GetMatrix();
            InitializePlayer(matrix);
            GetCommands(matrix);
            PrintOutcome(matrix);
        }

        private static void InitializePlayer(char[][] matrix)
        {
            playerStatus = Status.alive;
            playerPosition = GetPlayerPosition(matrix);
        }

        private static void GetCommands(char[][] matrix)
        {
            var commands = Console.ReadLine().Trim().ToCharArray();

            foreach (var command in commands)
            {
                MovePlayer(matrix, command);
                PopulateBunnies(matrix);

                if (playerStatus != Status.alive)
                {
                    break;
                }
            }
        }

        private static void PrintOutcome(char[][] matrix)
        {
            PrintMatrix(matrix);
            Console.WriteLine($"{playerStatus}: {string.Join(" ", playerPosition)}");
        }

        private static void ReplaceNewBunnies(char[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[0].Length; col++)
                {
                    if (matrix[row][col] == newBunny)
                    {
                        matrix[row][col] = bunny;
                    }
                }
            }
        }

        private static void AddNewBunny(char[][] matrix, int row, int col)
        {
            if (IsInsideMatrix(matrix, row, col))
            {

                if (matrix[row][col] == player)
                {
                    playerStatus = Status.dead;
                }

                if (matrix[row][col] != bunny)
                {
                    matrix[row][col] = newBunny;
                }
            }
        }

        private static void PopulateBunnies(char[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[0].Length; col++)
                {
                    if (matrix[row][col] != bunny)
                    {
                        continue;
                    }

                    AddNewBunny(matrix, row - 1, col);
                    AddNewBunny(matrix, row + 1, col);
                    AddNewBunny(matrix, row, col - 1);
                    AddNewBunny(matrix, row, col + 1);
                }
            }

            ReplaceNewBunnies(matrix);
        }

        private static void MovePlayer(char[][] matrix, char command)
        {
            var nextPosition = new int[] { playerPosition[0], playerPosition[1] };

            switch (command)
            {
                case 'L': nextPosition[1] = playerPosition[1] - 1; break;
                case 'R': nextPosition[1] = playerPosition[1] + 1; break;
                case 'U': nextPosition[0] = playerPosition[0] - 1; break;
                case 'D': nextPosition[0] = playerPosition[0] + 1; break;
            }

            if (!IsInsideMatrix(matrix, nextPosition[0], nextPosition[1]))
            {
                playerStatus = Status.won;
                matrix[playerPosition[0]][playerPosition[1]] = vacantPosition;
            }

            else if (matrix[nextPosition[0]][nextPosition[1]] == vacantPosition)
            {
                matrix[nextPosition[0]][nextPosition[1]] = player;
                matrix[playerPosition[0]][playerPosition[1]] = vacantPosition;
                playerPosition[0] = nextPosition[0];
                playerPosition[1] = nextPosition[1];
            }

            else if (matrix[nextPosition[0]][nextPosition[1]] == bunny)
            {
                playerStatus = Status.dead;
                matrix[playerPosition[0]][playerPosition[1]] = vacantPosition;
                playerPosition[0] = nextPosition[0];
                playerPosition[1] = nextPosition[1];
            }
        }

        private static bool IsInsideMatrix(char[][] matrix, int r, int c)
        {
            return r >= 0 && r < matrix.Length && c >= 0 && c < matrix[0].Length;
        }

        private static int[] GetPlayerPosition(char[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[0].Length; col++)
                {
                    if (matrix[row][col] == player)
                    {
                        return new int[] { row, col };
                    }
                }
            }

            return new int[] { -1, -1 };
        }

        private static void PrintMatrix(char[][] matrix)
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
            var matrix = new char[size[0]][];

            for (int row = 0; row < size[0]; row++)

            {
                matrix[row] = Console.ReadLine().Trim().ToCharArray();
            }

            return matrix;
        }
    }
}
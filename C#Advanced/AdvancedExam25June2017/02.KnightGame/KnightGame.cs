using System;

namespace _02.KnightGame
{
    public class KnightGame
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var field = new bool[n, n];

            for (int row = 0; row < n; row++)
            {
                var inputLine = Console.ReadLine();
                for (int col = 0; col < n; col++)
                {
                    field[row, col] = inputLine[col] == 'K';
                }
            }

            int removedKnights = 0;
            while (true)
            {
                var possibleAttacks = new int[n, n];

                for (var row = 0; row < n; row++)
                {
                    for (var col = 0; col < n; col++)
                    {
                        if (!field[row, col])
                        {
                            possibleAttacks[row, col] = 0;
                            continue;
                        }
                        int attacks = 0;
                        if (!IsCellEmpty(row + 1, col + 2, field)) attacks++;
                        if (!IsCellEmpty(row + 2, col + 1, field)) attacks++;
                        if (!IsCellEmpty(row - 1, col + 2, field)) attacks++;
                        if (!IsCellEmpty(row - 2, col + 1, field)) attacks++;
                        if (!IsCellEmpty(row + 2, col - 1, field)) attacks++;
                        if (!IsCellEmpty(row + 1, col - 2, field)) attacks++;
                        if (!IsCellEmpty(row - 1, col - 2, field)) attacks++;
                        if (!IsCellEmpty(row - 2, col - 1, field)) attacks++;
                        possibleAttacks[row, col] = attacks;
                    }

                }

                int removePieceAtRow = -1;
                int removePieceAtCol = -1;
                for (var row = 0; row < n; row++)
                    for (var col = 0; col < n; col++)
                        if (possibleAttacks[row, col] > (removePieceAtRow >= 0 ? possibleAttacks[removePieceAtRow, removePieceAtCol] : 0))
                        {
                            removePieceAtRow = row;
                            removePieceAtCol = col;
                        }

                if (removePieceAtRow == -1)
                {
                    break;
                }

                removedKnights++;
                field[removePieceAtRow, removePieceAtCol] = false;
            }

            Console.WriteLine(removedKnights);
        }

        private static bool IsCellEmpty(int row, int col, bool[,] board)
        {
            return row < 0
                || row >= board.GetLength(0)
                || col < 0
                || col >= board.GetLength(1)
                || !board[row, col];
        }
    }
}
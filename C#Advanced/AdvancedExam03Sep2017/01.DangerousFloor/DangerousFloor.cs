using System;
using System.Linq;

namespace _01.DangerousFloor
{
    public class Program
    {
        public static void Main()
        {
            var field = new char[8,8];

            for (int row = 0; row < field.GetLength(0); row++)
            {
                var inputTokens = Console.ReadLine().Split(',').Select(char.Parse).ToArray();

                for (int col = 0; col < field.GetLength(1); col++)
                {
                    field[row, col] = inputTokens[col];
                }
            }

            string moveInfo;
            while ((moveInfo = Console.ReadLine()) != "END")
            {
                var pieceType = moveInfo[0];
                var startRow = int.Parse(moveInfo[1].ToString());
                var startCol = int.Parse(moveInfo[2].ToString());
                var finalRow = int.Parse(moveInfo[4].ToString());
                var finalCol = int.Parse(moveInfo[5].ToString());

                if (field[startRow, startCol] == 'x')
                {
                    Console.WriteLine("There is no such a piece!");
                    continue;
                }

                switch (pieceType)
                {
                    case 'K':
                        var isValidMove = (finalRow == startRow - 1 && finalCol == startCol - 1) 
                                   || (finalRow == startRow -1 && finalCol == startCol) 
                                   || (finalRow == startRow -1 && finalCol == startCol + 1) 
                                   || (finalRow == startRow  && finalCol == startCol + 1) 
                                   || (finalRow == startRow + 1 && finalCol == startCol + 1) 
                                   || (finalRow == startRow + 1 && finalCol == startCol) 
                                   || (finalRow == startRow + 1 && finalCol == startCol - 1) 
                                   || (finalRow == startRow && finalCol == startCol - 1);
                        if (!isValidMove)
                        {
                            Console.WriteLine("Invalid move!");
                            continue;
                        }

                        if (!IsOnTheField(finalRow, finalCol, field))
                        {
                            continue;
                        }

                        field[startRow, startCol] = 'x';
                        field[finalRow, finalCol] = 'K';
                        break;

                    case 'R':
                        if (finalRow != startRow && finalCol != startCol)
                        {
                            Console.WriteLine("Invalid move!");
                            continue;
                        }

                        if (!IsOnTheField(finalRow, finalCol, field))
                        {
                            continue;
                        }

                        field[startRow, startCol] = 'x';
                        field[finalRow, finalCol] = 'R';
                        break;

                    case 'B':
                        if ((Math.Abs(finalRow - startRow) != Math.Abs(finalCol - startCol)))
                        {
                            Console.WriteLine("Invalid move!");
                            continue;
                        }

                        if (!IsOnTheField(finalRow, finalCol, field))
                        {
                            continue;
                        }

                        field[startRow, startCol] = 'x';
                        field[finalRow, finalCol] = 'B';
                        break;

                    case 'Q':
                        if ((Math.Abs(finalRow - startRow) != Math.Abs(finalCol - startCol))
                            && (finalRow != startRow && finalCol != startCol))
                        {
                            Console.WriteLine("Invalid move!");
                            continue;
                        }
                        if (!IsOnTheField(finalRow, finalCol, field))
                        {
                            continue;
                        }

                        field[startRow, startCol] = 'x';
                        field[finalRow, finalCol] = 'Q';
                        break;

                    case 'P':
                        if (finalRow != startRow - 1 || finalCol != startCol)
                        {
                            Console.WriteLine("Invalid move!");
                            continue;
                        }

                        if (!IsOnTheField(finalRow, finalCol, field))
                        {
                            continue;
                        }

                        field[startRow, startCol] = 'x';
                        field[finalRow, finalCol] = 'P';
                        break;
                }
            }

        }
        public static bool IsOnTheField(int finalRow, int finalCol, char[,] field)
        {
            if (finalRow < 0 || finalRow >= field.GetLength(0) || finalCol < 0 || finalCol >= field.GetLength(1))
            {
                Console.WriteLine("Move go out of board!");
                return false;
            }

            return true;
        }
    }
}

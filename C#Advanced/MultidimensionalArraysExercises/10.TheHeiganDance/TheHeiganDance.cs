using System;

namespace _10.TheHeiganDance
{
    public class TheHeiganDance
    {
        private static int[][] matrix;
        private const double cloud = 3500.0;
        private const double eruption = 6000.0;

        public static void Main()
        {
            matrix = new int[15][];
            for (int rowIndex = 0; rowIndex < matrix.Length; rowIndex++)
            {
                matrix[rowIndex] = new int[15];
            }

            double playerHealth = 18500;
            double heiganHealth = 3000000;
            var playerRow = 7;
            var playerCol = 7;
            var damageForHeigan = double.Parse(Console.ReadLine());
            var lastMagic = string.Empty;

            while (true)
            {
                if (playerHealth >= 0)
                {
                    heiganHealth -= damageForHeigan;
                }
                if (lastMagic == "Cloud")
                {
                    playerHealth -= cloud;
                }
                if (playerHealth <= 0 || heiganHealth <= 0)
                {
                    break;
                }

                var commandTokens = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var magic = commandTokens[0];
                var targetRow = int.Parse(commandTokens[1]);
                var targetCol = int.Parse(commandTokens[2]);

                //check if the player is in the range of the magic
                if (InMagicRange(targetRow, targetCol, playerRow, playerCol))
                {
                    if (!InMagicRange(targetRow, targetCol, playerRow - 1, playerCol) && !IsWall(playerRow - 1))
                    {
                        playerRow--;
                        lastMagic = string.Empty;
                    }
                    //down
                    else if (!InMagicRange(targetRow, targetCol, playerRow + 1, playerCol) && !IsWall(playerRow + 1))
                    {
                        playerRow++;
                        lastMagic = string.Empty;
                    }
                    //left
                    else if (!InMagicRange(targetRow, targetCol, playerRow, playerCol - 1) && !IsWall(playerCol - 1))
                    {
                        playerCol--;
                        lastMagic = string.Empty;
                    }
                    //right
                    else if (!InMagicRange(targetRow, targetCol, playerRow, playerCol + 1) && !IsWall(playerCol + 1))
                    {
                        playerCol++;
                        lastMagic = string.Empty;
                    }
                    else
                    {
                        lastMagic = magic;
                        if (magic == "Cloud")
                        {
                            playerHealth -= cloud;
                        }
                        else if (magic == "Eruption")
                        {
                            playerHealth -= eruption;
                        }
                    }
                }
            }

            if (lastMagic == "Cloud")
            {
                lastMagic = "Plague Cloud";
            }
            else
            {
                lastMagic = "Eruption";
            }

            if (heiganHealth <= 0 && playerHealth > 0)
            {
                Console.WriteLine("Heigan: Defeated!");
                Console.WriteLine($"Player: {playerHealth}");
                Console.WriteLine($"Final position: {playerRow}, {playerCol}");
            }
            else if (playerHealth <= 0 && heiganHealth > 0)
            {
                Console.WriteLine($"Heigan: {heiganHealth:F2}");
                Console.WriteLine($"Player: Killed by {lastMagic}");
                Console.WriteLine($"Final position: {playerRow}, {playerCol}");
            }
            else
            {
                Console.WriteLine("Heigan: Defeated!");
                Console.WriteLine($"Player: Killed by {lastMagic}");
                Console.WriteLine($"Final position: {playerRow}, {playerCol}");
            }
        }

        private static bool InMagicRange(int targetRow, int targetCol, int moveRow, int moveCol)
        {
            return ((targetRow - 1 <= moveRow && moveRow <= targetRow + 1)
                    && (targetCol - 1 <= moveCol && moveCol <= targetCol + 1));
        }

        private static bool IsWall(int rowOrCol)
        {
            return rowOrCol < 0 || rowOrCol >= 15;
        }
    }
}
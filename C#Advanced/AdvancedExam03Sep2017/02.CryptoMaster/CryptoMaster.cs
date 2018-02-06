using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.CryptoMaster
{
    public class CryptoMaster
    {
        public static void Main()
        {
            
            var safe = Console.ReadLine()
                .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            
            int longestCount = 1;
            for (int safePiece = 0; safePiece < safe.Length; safePiece++)
            {
                for (int step = 0; step < safe.Length; step++)
                {
                    int currentCount = 1;
                    int currentPosition = safePiece;

                    while (safe[currentPosition % safe.Length] > safe[(currentPosition += step) % safe.Length])
                    {
                        currentCount++;
                    }

                    if (currentCount > longestCount)
                    {
                        longestCount = currentCount;
                    }
                }
            }

            Console.WriteLine(longestCount);    
        }
    }
}

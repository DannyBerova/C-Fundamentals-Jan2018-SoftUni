using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01.Problem
{
    public class ProblemOne
    {
        public static void Main()
        {
            var priceOfBullet = int.Parse(Console.ReadLine());
            var sizeOfBarrel = int.Parse(Console.ReadLine());
            var bullets = new Queue<long>(Console.ReadLine().Split().Select(long.Parse).Reverse());
            var locks = new Queue<long>(Console.ReadLine().Split().Select(long.Parse));
            var budget = int.Parse(Console.ReadLine());
            var gameEnded = false;

            while (bullets.Count > 0 && locks.Count > 0)
            {
                for (int i = 0; i < sizeOfBarrel; i++)
                {
                    if (bullets.Count == 0 || locks.Count == 0)
                    {
                        gameEnded = true;
                        break;
                    }

                    var currentBullet = bullets.Dequeue();
                        var currentLock = locks.Peek();

                        if (currentBullet <= currentLock)
                        {
                            Console.WriteLine($"Bang!");
                            budget -= priceOfBullet;
                            locks.Dequeue();
                        }
                        else
                        {
                            Console.WriteLine("Ping!");
                            budget -= priceOfBullet;
                        }
                    
                }

                if (gameEnded || bullets.Count == 0)
                {
                    break;
                }
                Console.WriteLine("Reloading!");
                

            }

            if (locks.Count > 0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
            else
            {
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${budget}");
            }
        }
    }
}

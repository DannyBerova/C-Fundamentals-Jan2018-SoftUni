using System;
using System.Collections.Generic;

namespace _04.HotPotato
{
    public class Program
    {
        public static void Main()
        {
            var people = Console.ReadLine().Split();
            var roundToss = int.Parse(Console.ReadLine());

            var queue = new Queue<string>(people);

            while (queue.Count != 1)
            {
                for (int roundTossCounter = 1; roundTossCounter < roundToss; roundTossCounter++)
                {
                    queue.Enqueue(queue.Dequeue());
                }
                Console.WriteLine($"Removed {queue.Dequeue()}");
            }

            Console.WriteLine($"Last is {queue.Dequeue()}");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.BasicQueueOperations
{
    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine()
                        .Trim()
                        .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();

            var elements = Console.ReadLine()
                        .Trim()
                        .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();

            int elementsToRemove = input[1];
            int element = input[2];

            var elementsQueue = new Queue<int>(elements);

            for (int i = 0; i < elementsToRemove; i++)
            {
                elementsQueue.Dequeue();
            }

            if (elementsQueue.Contains(element))
            {
                Console.WriteLine("true");
            }
            else if (elementsQueue.Count == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                Console.WriteLine(elementsQueue.Min());
            }
        }
    }
}

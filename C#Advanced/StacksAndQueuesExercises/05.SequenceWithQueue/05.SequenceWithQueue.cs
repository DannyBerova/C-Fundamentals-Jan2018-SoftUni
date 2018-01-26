using System;
using System.Collections.Generic;

namespace _05.SequenceWithQueue
{
    public class SequenceWithQueue
    {
        public static void Main()
        {
            var n = long.Parse(Console.ReadLine());

            var elements = new Queue<long>();
            elements.Enqueue(n);

            var currentNumber = new Queue<long>();

            while (elements.Count < 50)
            {
                elements.Enqueue(n + 1);
                currentNumber.Enqueue(n + 1);

                if (elements.Count < 50)
                {
                    elements.Enqueue(2 * n + 1);
                    currentNumber.Enqueue(2 * n + 1);
                }

                if (elements.Count < 50)
                {
                    elements.Enqueue(n + 2);
                    currentNumber.Enqueue(n + 2);
                    n = currentNumber.Dequeue();
                }

            }

            Console.WriteLine(string.Join(" ", elements));

        }
    }
}

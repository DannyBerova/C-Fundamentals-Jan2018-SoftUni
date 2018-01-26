using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.BasicStackOpertaions
{
    public class StackOperations
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split();

            var elements = Console.ReadLine()
                          .Split()
                          .Select(int.Parse)
                          .ToArray();

            var elementsToPop = int.Parse(input[1]);
            var elementToCheck = int.Parse(input[2]);

            var numbersStack = new Stack<int>(elements);

            for (int cnt = 0; cnt < elementsToPop; cnt++)
            {
                numbersStack.Pop();
            }

            if (numbersStack.Count == 0)
            {
                Console.WriteLine(0);
            }
            else if (numbersStack.Contains(elementToCheck))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(numbersStack.Min());
            }

        }
    }
}
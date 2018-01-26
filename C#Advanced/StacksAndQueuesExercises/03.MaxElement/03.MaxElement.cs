using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MaxElement
{
    public class MaxElement
    {
        public static void Main()
        {
            var queriesCount = int.Parse(Console.ReadLine());
            var elements = new Stack<int>();
            var maxElements = new Stack<int>();

            for (int i = 0; i < queriesCount; i++)
            {
                var args = Console.ReadLine()
                            .Trim()
                            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToArray();

                var command = args[0];

                switch (command)
                {
                    case 1:
                        int currentElement = args[1];
                        elements.Push(currentElement);

                        if (maxElements.Count == 0 || maxElements.Peek() < currentElement)
                        {
                            maxElements.Push(currentElement);
                        }
                        break;
                    case 2:
                        if (elements.Count != 0)
                        {
                            int removedElement = elements.Pop();
                            if (maxElements.Count != 0 && maxElements.Peek() == removedElement)
                            {
                                maxElements.Pop();
                            }
                        }
                        break;
                    case 3:
                        if (maxElements.Count != 0)
                        {
                            Console.WriteLine(maxElements.Peek());
                        }
                        break;
                }
            }
        }
    }
}
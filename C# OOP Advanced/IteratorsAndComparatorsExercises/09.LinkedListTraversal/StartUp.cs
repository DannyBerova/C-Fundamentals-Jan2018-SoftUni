using System;

namespace _09.LinkedListTraversal
{
    public class Startup
    {
        public static void Main()
        {
            var linkedList = new LinkedList<int>();
            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var commandArgs = Console.ReadLine().Split();
                var command = commandArgs[0];

                switch (command)
                {
                    case "Add":
                        var elementToAdd = int.Parse(commandArgs[1]);
                        linkedList.Add(elementToAdd);
                        break;
                    case "Remove":
                        var elementToRemove = int.Parse(commandArgs[1]);
                        linkedList.Remove(elementToRemove);
                        break;
                }
            }

            Console.WriteLine(linkedList.Count);
            Console.WriteLine(string.Join(" ", linkedList));
        }
    }
}

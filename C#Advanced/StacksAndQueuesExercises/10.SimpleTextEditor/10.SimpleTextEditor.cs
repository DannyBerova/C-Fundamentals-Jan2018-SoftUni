using System;
using System.Collections.Generic;

namespace _10.SimpleTextEditor
{
    public class Program
    {
        public static void Main()
        {
            var operationsCount = int.Parse(Console.ReadLine());
            var text = String.Empty;
            var oldVersions = new Stack<string>();

            for (int i = 0; i < operationsCount; i++)
            {
                var args = Console.ReadLine()
                            .Trim()
                            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                int operation = int.Parse(args[0]);

                switch (operation)
                {
                    case 1:
                        oldVersions.Push(text);
                        text += args[1];
                        break;
                    case 2:
                        oldVersions.Push(text);
                        int charsToRemove = int.Parse(args[1]);
                        text = text.Substring(0, text.Length - charsToRemove);
                        break;
                    case 3:
                        int searchedIndex = int.Parse(args[1]);
                        Console.WriteLine(text[searchedIndex - 1]);
                        break;
                    case 4:
                        text = oldVersions.Pop();
                        break;
                }
            }
        }
    }
}
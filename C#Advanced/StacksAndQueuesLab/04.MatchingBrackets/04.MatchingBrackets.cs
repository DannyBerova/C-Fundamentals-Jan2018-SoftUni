using System;
using System.Collections.Generic;

namespace _04.MatchingBrackets
{
    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var stackOpenBracketIndex = new Stack<int>();

            for (int index = 0; index < input.Length; index++)
            {
                if (input[index] == '(')
                {
                    stackOpenBracketIndex.Push(index);
                }

                if (input[index] == ')')
                {
                    var openBracketIndex = stackOpenBracketIndex.Pop();
                    var length = index - openBracketIndex + 1;
                    Console.WriteLine(input.Substring(openBracketIndex, length));
                }
            }
        }
    }
}

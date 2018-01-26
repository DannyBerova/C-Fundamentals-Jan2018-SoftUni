using System;
using System.Collections.Generic;

namespace _01.ReverseStrings
{
    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine().ToCharArray();
            var stack = new Stack<char>();

            for (int i = 0; i < input.Length; i++)
            {
                stack.Push(input[i]);
            }

            for (int i = 0; i < input.Length; i++)
            {
                Console.Write(stack.Pop());
            }
            Console.WriteLine();
        }
    }
}

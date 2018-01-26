using System;
using System.Collections.Generic;

namespace _03.DecimalToBinaryConverter
{
    public class Program
    {
        public static void Main()
        {
            var input = long.Parse(Console.ReadLine());

            var stack = new Stack<long>();

            if (input == 0)
            {
                Console.WriteLine(0);
                Environment.Exit(0);
            }

            while (input > 0)
            {
                stack.Push(input % 2);
                input /= 2;
            }

            while (stack.Count > 0)
            {
                Console.Write(stack.Pop()); 
            }
            Console.WriteLine();
        }
    }
}

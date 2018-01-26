using System;
using System.Collections.Generic;

namespace _01.ReverseNumbersWithAStack
{
    public class Program
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().Split();
            var numbersStack = new Stack<string>(numbers);

            Console.WriteLine(string.Join(" ", numbersStack));

        }
    }
}

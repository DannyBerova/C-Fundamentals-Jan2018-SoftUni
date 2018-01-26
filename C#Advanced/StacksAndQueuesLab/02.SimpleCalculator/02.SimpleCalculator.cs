using System;
using System.Collections.Generic;

namespace _02.SimpleCalculator
{
    public class Program
    {
        public static void Main()
        {
            var elements = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var stack = new Stack<string>();

            for (int i = elements.Length - 1; i >= 0; i--)
            {
                stack.Push(elements[i]);
            }

            while (stack.Count > 1)
            {
                var leftOperand = int.Parse(stack.Pop());
                var operation = stack.Pop();
                var rightOperand = int.Parse(stack.Pop());

                switch (operation)
                {
                    case "+":
                        stack.Push((leftOperand + rightOperand).ToString());
                        break;
                    case "-":
                        stack.Push((leftOperand - rightOperand).ToString());
                        break;
                }
            }

            Console.WriteLine(stack.Pop());
        }
    }
}

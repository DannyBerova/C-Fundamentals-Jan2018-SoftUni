using System;
using System.Collections.Generic;

namespace _09.StackFibonacci
{
    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(GetFibonacci(n));
        }

        private static long GetFibonacci(int n)
        {
            var fibonacciSequence = new Stack<long>(new[] { 0, 1L });

            for (int i = 0; i < n - 1; i++)
            {
                long nMinus1 = fibonacciSequence.Pop();
                long nMinus2 = fibonacciSequence.Peek();
                fibonacciSequence.Push(nMinus1);
                fibonacciSequence.Push(nMinus1 + nMinus2);
            }

            return fibonacciSequence.Peek();
        }
    }
}
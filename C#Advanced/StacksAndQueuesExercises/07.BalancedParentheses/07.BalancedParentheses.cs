using System;
using System.Collections.Generic;

namespace _07.BalancedParentheses
{
    public class Program
    {
        public static void Main()
        {
            var parantheses = Console.ReadLine()
                            .Trim()
                            .ToCharArray();

            var stack = new Stack<char>();
            var parenthesesPair = new Dictionary<char, char>();
            parenthesesPair['{'] = '}';
            parenthesesPair['['] = ']';
            parenthesesPair['('] = ')';

            if (parantheses.Length % 2 != 0 || parantheses.Length == 0)
            {
                Console.WriteLine("NO");
                return;
            }

            foreach (var p in parantheses)
            {
                if (parenthesesPair.ContainsKey(p))
                {
                    stack.Push(p);
                }
                else
                {
                    var openParentheses = stack.Pop();
                    if (parenthesesPair[openParentheses] != p)
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                }
            }

            Console.WriteLine("YES");
        }
    }
}
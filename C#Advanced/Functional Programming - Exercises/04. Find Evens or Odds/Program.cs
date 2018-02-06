namespace _04.Find_Evens_or_Odds
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var range = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .OrderBy(n => n)
                .ToList();
            var oddOrEven = Console.ReadLine().ToLower();

            Predicate<int> isEven = n => n % 2 == 0;

            var numbers = GetNumbers(range, oddOrEven, isEven);

            if (numbers.Count != 0)
            {
                Console.WriteLine(string.Join(" ", numbers));
            }
        }

        private static List<int> GetNumbers(List<int> range, string oddOrEven, Predicate<int> isEven)
        {
            var numbers = new List<int>();

            for (int n = range[0]; n <= range[1]; n++)
            {
                if ((isEven(n) && oddOrEven == "even") || (!isEven(n) && oddOrEven == "odd"))
                {
                    numbers.Add(n);
                }
            }

            return numbers;
        }
    }
}

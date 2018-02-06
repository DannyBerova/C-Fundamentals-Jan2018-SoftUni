namespace _08.Custom_Comparator
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            Predicate<int> isEven = n => n % 2 == 0;

            var numbers = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .GroupBy(n => isEven(n))
                .OrderByDescending(g => g.Key)
                .ToDictionary(g => g.Key, g => g.OrderBy(n => n).ToList());

            foreach (var grpNumbers in numbers)
            {
                Console.Write(string.Join(" ", grpNumbers.Value) + " ");
            }
        }
    }
}

namespace _06.Reverse_And_Exclude
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            var divisor = int.Parse(Console.ReadLine());

            Predicate<int> isDivisible = n => n % divisor == 0;

            var notDivisibleNumbers = numbers
                .Where(n => !isDivisible(n))
                .Reverse()
                .ToList();

            Console.WriteLine(string.Join(" ", notDivisibleNumbers));
        }
    }
}

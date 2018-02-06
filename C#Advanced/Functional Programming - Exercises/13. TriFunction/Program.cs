namespace _13.TriFunction
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var sum = int.Parse(Console.ReadLine());
            var names = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Func<string, int> sumChars = str => str.ToCharArray().Sum(ch => ch);
            Func<string, int, bool> isEqualOrLargerSum = (str, n) => sumChars(str) >= n;

            var name = names.FirstOrDefault(n => isEqualOrLargerSum(n, sum));

            Console.WriteLine(name);
        }
    }
}

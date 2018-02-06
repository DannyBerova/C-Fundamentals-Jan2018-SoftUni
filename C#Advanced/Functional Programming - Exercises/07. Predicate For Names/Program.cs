namespace _07.Predicate_For_Names
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            int length = int.Parse(Console.ReadLine());

            Predicate<string> hasValidLength = s => s.Length <= length;

            Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Where(s => hasValidLength(s))
                .ToList()
                .ForEach(n => Console.WriteLine(n));
        }
    }
}

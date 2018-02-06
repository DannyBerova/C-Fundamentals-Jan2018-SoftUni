namespace _03.Custom_Min_Function
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToList();

            Func<List<double>, double> minNumber = n => n.Min();

            Console.WriteLine(minNumber(numbers));
        }
    }
}

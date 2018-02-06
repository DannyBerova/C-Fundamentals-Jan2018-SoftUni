namespace _02.Knights_of_Honor
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var persons = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Action<string> print = x => Console.WriteLine("Sir {0}", x);

            foreach (var p in persons)
            {
                print(p);
            }
        }
    }
}

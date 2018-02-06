namespace _01.Action_Print
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var persons = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Action<string> print = x => Console.WriteLine(x);

            foreach (var p in persons)        
            {
                print(p);
            }
        }
    }
}

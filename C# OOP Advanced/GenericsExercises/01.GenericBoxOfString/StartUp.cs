using System;

namespace _01.GenericBoxOfString
{
    public class Startup
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var box = new Box<string>(Console.ReadLine());
                Console.WriteLine(box);
            }
        }
    }
}

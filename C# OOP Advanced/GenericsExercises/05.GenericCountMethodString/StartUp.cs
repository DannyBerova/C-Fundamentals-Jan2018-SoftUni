using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.GenericCountMethodString
{
    public class Startup
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var boxes = new List<Box<string>>();

            for (int i = 0; i < n; i++)
            {
                var box = new Box<string>(Console.ReadLine());
                boxes.Add(box);
            }

            var elementToCompare = Console.ReadLine();

            var count = GetCountOfGreatherElements(boxes, elementToCompare);
            Console.WriteLine(count);
        }

        private static int GetCountOfGreatherElements<T>(List<Box<T>> boxes, T elementToCompare)
            where T : IComparable<T>
        {
            var count = boxes.Count(b => b.Value.CompareTo(elementToCompare) > 0);
            return count;
        }
    }
}

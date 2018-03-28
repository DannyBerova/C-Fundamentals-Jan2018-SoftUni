using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.GenericSwapMethodString
{
    class StartUp
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

            var indexes = Console.ReadLine().Split();
            var firstIndex = int.Parse(indexes[0]);
            var secondIndex = int.Parse(indexes[1]);

            GenericSwapMethodString(boxes, firstIndex, secondIndex);

            Console.WriteLine(String.Join(Environment.NewLine, boxes));
        }

        private static void GenericSwapMethodString<T>(List<Box<T>> boxes, int firstIndex, int secondIndex)
        {
            Box<T> firstBox = boxes[firstIndex];
            boxes[firstIndex] = boxes[secondIndex];
            boxes[secondIndex] = firstBox;
        }
    }
}

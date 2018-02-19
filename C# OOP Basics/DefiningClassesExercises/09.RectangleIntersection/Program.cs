using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        var input = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        var rectangles = new List<Rectangle>();

        var numberOfRectangles = int.Parse(input[0]);
        var intersectionChecks = int.Parse(input[1]);

        for (int i = 0; i < numberOfRectangles; i++)
        {
            var rectangleInfo = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var rectangle = new Rectangle(
                rectangleInfo[0],
                double.Parse(rectangleInfo[1]),
                double.Parse(rectangleInfo[2]),
                double.Parse(rectangleInfo[3]),
                double.Parse(rectangleInfo[4]));

            rectangles.Add(rectangle);
        }

        for (int i = 0; i < intersectionChecks; i++)
        {
            var args = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var firstRectangle = rectangles.FirstOrDefault(r => r.Id == args[0]);
            var secondRectangle = rectangles.FirstOrDefault(r => r.Id == args[1]);

            if (firstRectangle == null || secondRectangle == null)
            {
                Console.WriteLine("false");
            }
            else
            {
                Console.WriteLine(firstRectangle.IntersectsRectangle(secondRectangle) ? "true" : "false");
            }
        }
    }
}
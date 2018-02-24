using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        var rectangle = new Rectangle(Console.ReadLine());
        var pointsCount = int.Parse(Console.ReadLine());

        for (int counter = 0; counter < pointsCount; counter++)
        {
            //var pointCoords = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            //var point = new Point(pointCoords[0], pointCoords[1]);
            var point = new Point(Console.ReadLine);
            var containsPoint = rectangle.Contains(point);

            Console.WriteLine(containsPoint);
        }
    }
}

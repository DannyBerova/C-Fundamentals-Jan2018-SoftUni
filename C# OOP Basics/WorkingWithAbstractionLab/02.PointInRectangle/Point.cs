using System;
using System.Linq;

public class Point
{
    public int X { get; set; }
    public int Y { get; set; }

    public Point(int x, int y)
    {
        this.X = x;
        this.Y = y;
    }

    public Point(Func<string> readPoint)
    {
        var pointCoords = readPoint().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
        this.X = pointCoords[0];
        this.Y = pointCoords[1];
    }
}


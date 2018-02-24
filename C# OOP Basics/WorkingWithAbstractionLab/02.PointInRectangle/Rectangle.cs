using System;
using System.Linq;

public class Rectangle
{
    public Point TopLeft { get; set; }
    public Point BottomRight { get; set; }

    public Rectangle(int topX, int topY, int bottomX, int bottomY)
    {
        TopLeft = new Point(topX, topY);
        BottomRight = new Point(bottomX, bottomY);
    }

    public Rectangle(string coordsLine)
    {
        var coords = coordsLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
        TopLeft = new Point(coords[0], coords[1]);
        BottomRight = new Point(coords[2], coords[3]);
    }

    public bool Contains(Point point)
    {
        var contains =
            point.X >= TopLeft.X && point.X <= BottomRight.X &&
            point.Y >= TopLeft.Y && point.Y <= BottomRight.Y;
        return contains;
    }
}


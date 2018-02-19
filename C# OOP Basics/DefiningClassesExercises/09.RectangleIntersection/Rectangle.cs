public class Rectangle
{
    private string id;
    private double width;
    private double height;
    private double coordinatesTopLeftX;
    private double coordinatesTopLeftY;

    public Rectangle(string id, double width, double height, double coordinatesTopLeftY, double coordinatesTopLeftX)
    {
        this.Id = id;
        this.Width = width;
        this.Height = height;
        this.CoordinatesTopLeftX = coordinatesTopLeftX;
        this.CoordinatesTopLeftY = coordinatesTopLeftY;

    }

    public string Id
    {
        get { return this.id; }
        set { this.id = value; }
    }

    public double Width
    {
        get { return this.width; }
        set { this.width = value; }
    }

    public double Height
    {
        get { return this.height; }
        set { this.height = value; }
    }

    public double CoordinatesTopLeftX
    {
        get { return this.coordinatesTopLeftX; }
        set { this.coordinatesTopLeftX = value; }
    }

    public double CoordinatesTopLeftY
    {
        get { return this.coordinatesTopLeftY; }
        set { this.coordinatesTopLeftY = value; }
    }

    public bool IntersectsRectangle(Rectangle r)
    {
        return this.ContainsRectangleCorner(r) || r.ContainsRectangleCorner(this);
    }

    private bool ContainsRectangleCorner(Rectangle r)
    {
        return this.ContainsPoint(r.coordinatesTopLeftX, r.coordinatesTopLeftY) ||
               this.ContainsPoint(r.coordinatesTopLeftX, r.coordinatesTopLeftY + height) ||
               this.ContainsPoint(r.coordinatesTopLeftX + width, r.coordinatesTopLeftY) ||
               this.ContainsPoint(r.coordinatesTopLeftX + width, r.coordinatesTopLeftY + height);
    }

    private bool ContainsPoint(double x, double y)
    {
        return x >= this.coordinatesTopLeftX && x <= this.coordinatesTopLeftX + width &&
               y >= this.coordinatesTopLeftY && y <= this.coordinatesTopLeftY + height;
    }
}
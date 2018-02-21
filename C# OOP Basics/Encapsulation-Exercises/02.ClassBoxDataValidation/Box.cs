using System;

public class Box
{
    private double length;
    private double width;
    private double height;

    public Box(double length, double width, double height)
    {
        this.Length = length;
        this.Width = width;
        this.Height = height;
    }

    public double Length
    {
        get
        {
            return this.length;
        }

        private set
        {
            if (value <= 0)
            {
                throw new Exception("Length cannot be zero or negative.");
            }
            else
            {
                this.length = value;
            }
        }
    }

    public double Width
    {
        get
        {
            return this.width;
        }

        private set
        {
            if (value <= 0)
            {
                throw new Exception("Width cannot be zero or negative.");
            }
            else
            {
                this.width = value;
            }
        }
    }

    public double Height
    {
        get
        {
            return this.height;
        }

        private set
        {
            if (value <= 0)
            {
                throw new Exception("Height cannot be zero or negative.");
            }
            else
            {
                this.height = value;
            }
        }
    }

    public double SurfaceArea()
    {
        double surfaceArea = (2 * this.Length * this.Width) +
                            (2 * this.Length * this.Height) +
                            (2 * this.Width * this.Height);
        return surfaceArea;
    }

    public double LateralSurfaceArea()
    {
        double lateralSurfaceArea = (2 * this.Length * this.Height) +
                                    (2 * this.Width * this.Height);
        return lateralSurfaceArea;
    }

    public double Volume()
    {
        double volume = this.Length * this.Width * this.Height;
        return volume;
    }
}


using System;
public class Box
{
    private double lenght;
    private double width;
    private double height;

    public Box(double lenght, double width, double height)
    {
        this.Lenght = lenght;
        this.Width = width;
        this.Height = height;
    }

    public double Lenght
    {
        get
        {
            return this.lenght;
        }

        private set
        {
            this.lenght = value;
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
            this.width = value;
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
            this.height = value;
        }
    }
    public double SurfaceArea()
    {
        double surfaceArea = (2 * this.Lenght * this.Width) +
                            (2 * this.Lenght * this.Height) +
                            (2 * this.Width * this.Height);
        return surfaceArea;
    }

    public double LateralSurfaceArea()
    {
        double lateralSurfaceArea = (2 * this.Lenght * this.Height) +
                                    (2 * this.Width * this.Height);
        return lateralSurfaceArea;
    }

    public double Volume()
    {
        double volume = this.Lenght * this.Width * this.Height;
        return volume;
    }

}


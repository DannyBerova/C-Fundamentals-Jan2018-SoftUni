using System;


public class StartUp1
{
    static void Main(string[] args)
    {
        double lenght = double.Parse(Console.ReadLine());
        double width = double.Parse(Console.ReadLine());
        double height = double.Parse(Console.ReadLine());

        Box box = new Box(lenght, width, height);

        double surfaceArea = box.SurfaceArea();
        double lateralSurfaceArea = box.LateralSurfaceArea();
        double volume = box.Volume();

        Console.WriteLine($"Surface Area - {surfaceArea:f2}");
        Console.WriteLine($"Lateral Surface Area - {lateralSurfaceArea:f2}");
        Console.WriteLine($"Volume - {volume:f2}");

    }
}

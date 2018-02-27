using System;

public class StartUp
{
    public static void Main()
    {
        var driverName = Console.ReadLine();

        var ferrari = new Ferrari(driverName);
        Console.WriteLine(ferrari);
    }
}


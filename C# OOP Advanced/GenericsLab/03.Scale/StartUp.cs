using System;

public class StartUp
{
    public static void Main()
    {
        var scale = new Scale<int>(18, 8);
        var scale2 = new Scale<string>("aaa", "aaa");
        var scale3 = new Scale<double>(0.1, 0.5);

        Console.WriteLine(scale.GetHeavier());
        Console.WriteLine(scale2.GetHeavier());
        Console.WriteLine(scale3.GetHeavier());

    }
}


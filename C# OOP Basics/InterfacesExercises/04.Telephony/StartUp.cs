using System;

public class StartUp
{
    public static void Main()
    {
        var numbers = Console.ReadLine().Split();
        var urls = Console.ReadLine().Split();

        var smartphone = new Smartphone();

        foreach (var number in numbers)
        {
            Console.WriteLine(smartphone.Calling(number));
        }

        foreach (var url in urls)
        {
            Console.WriteLine(smartphone.Browsing(url));
        }
    }
}


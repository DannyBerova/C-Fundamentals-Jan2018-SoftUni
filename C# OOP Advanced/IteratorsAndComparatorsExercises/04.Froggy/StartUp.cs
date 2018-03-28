using System;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        var numbersInput = Console.ReadLine()
            .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        var lake = new Lake(numbersInput);

        Console.WriteLine(string.Join(", ", lake));
    }
}


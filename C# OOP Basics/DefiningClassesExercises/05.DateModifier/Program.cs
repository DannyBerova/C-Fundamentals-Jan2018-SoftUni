using System;
public class Program
{
    public static void Main()
    {
        string firstDate = Console.ReadLine();
        string secondDate = Console.ReadLine();

        Console.WriteLine(DateModifier.CalculateDateDifference(firstDate, secondDate));
    }
}

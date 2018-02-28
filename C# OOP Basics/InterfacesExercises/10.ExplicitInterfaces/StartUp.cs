using System;

public class StartUp
{
    public static void Main()
    {
        var input = Console.ReadLine();

        while (input != "End")
        {
            var tokens = input.Split();
            var citizen = new Citizen(tokens[0], tokens[1], int.Parse(tokens[2]));

            Console.WriteLine(((IPerson)citizen).GetName());
            Console.WriteLine(((IResident)citizen).GetName());

            input = Console.ReadLine();
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        var birthableGuys = new List<IBirthable>();

        var inputLine = Console.ReadLine();

        while (inputLine != "End")
        {
            var inputArgs = inputLine.Split().ToList();
            var typeOfMember = inputArgs[0];
            inputArgs.RemoveAt(0);

            IBirthable currentMember;

            switch (typeOfMember)
            {
                case "Citizen":
                    currentMember = new Citizen(inputArgs[0], int.Parse(inputArgs[1]), inputArgs[2], inputArgs[3]);
                    birthableGuys.Add(currentMember);
                    break;
                case "Pet":
                    currentMember = new Pet(inputArgs[0], inputArgs[1]);
                    birthableGuys.Add(currentMember);
                    break;
                default:
                    break;
            }

            inputLine = Console.ReadLine();
        }

        var yearPattern = Console.ReadLine();
        var filteredGuys = birthableGuys
            .Where(m => m.Birthdate.EndsWith(yearPattern))
            .ToArray();

        foreach (IBirthable member in filteredGuys)
        {
            Console.WriteLine(member.Birthdate);
        }
    }
}


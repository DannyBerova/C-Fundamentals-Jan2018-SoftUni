using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        var society = new List<IIdentable>();

        var inputLine = Console.ReadLine();

        while (inputLine != "End")
        {
            var inputArgs = inputLine.Split();
            IIdentable currentMember;
            if (inputArgs.Length == 3)
            {
                currentMember = new Citizen(inputArgs[0], int.Parse(inputArgs[1]), inputArgs[2]);
            }
            else
            {
                currentMember = new Robot(inputArgs[0], inputArgs[1]);
            }

            society.Add(currentMember);

            inputLine = Console.ReadLine();
        }

        var fakeIdsPatern = Console.ReadLine();
        foreach (IIdentable member in society.Where(m => m.Id.EndsWith(fakeIdsPatern)))
        {
            Console.WriteLine(member.Id);
        }
    }
}


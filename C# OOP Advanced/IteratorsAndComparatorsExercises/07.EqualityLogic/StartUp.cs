using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main()
    {
        var hashSetGuys = new HashSet<Person>();
        var sortedSetGuys = new SortedSet<Person>();

        var n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            var inputArgs = Console.ReadLine().Split();
            var name = inputArgs[0];
            var age = int.Parse(inputArgs[1]);
            var newPerson = new Person(name, age);

            hashSetGuys.Add(newPerson);
            sortedSetGuys.Add(newPerson);
        }

        Console.WriteLine(sortedSetGuys.Count);
        Console.WriteLine(hashSetGuys.Count);
    }
}


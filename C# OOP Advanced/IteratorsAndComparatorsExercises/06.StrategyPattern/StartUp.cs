using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main()
    {
        var sortedByNameSet = new SortedSet<Person>(new PersonByNameComparator());
        var sortedByAgeSet = new SortedSet<Person>(new PersonByAgeComparator());

        var n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            var inputArgs = Console.ReadLine().Split();
            var name = inputArgs[0];
            var age = int.Parse(inputArgs[1]);
            var newPerson = new Person(name, age);

            sortedByNameSet.Add(newPerson);
            sortedByAgeSet.Add(newPerson);
        }

        foreach (var personByName in sortedByNameSet)
        {
            Console.WriteLine($"{personByName.Name} {personByName.Age}");
        }

        foreach (var personByAge in sortedByAgeSet)
        {
            Console.WriteLine($"{personByAge.Name} {personByAge.Age}");
        }
    }
}


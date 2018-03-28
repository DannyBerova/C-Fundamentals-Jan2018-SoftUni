using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main()
    {
        var guys = new List<Person>();

        string input;
        while ((input = Console.ReadLine()) != "END")
        {
            var args = input.Split();
            var name = args[0];
            var age = int.Parse(args[1]);
            var town = args[2];
            var currentPerson = new Person(name, age, town);
            guys.Add(currentPerson);
        }

        var searchedPersonIndex = int.Parse(Console.ReadLine());
        var personToCompare = guys[searchedPersonIndex - 1];

        var numOfEqualPeople = 0;
        var numOfNotEqualPeople = 0;

        foreach (var person in guys)
        {
            if (personToCompare.CompareTo(person) == 0)
            {
                numOfEqualPeople++;
            }
            else
            {
                numOfNotEqualPeople++;
            }
        }

        if (numOfEqualPeople == 1)
        {
            Console.WriteLine("No matches");
        }
        else
        {
            Console.WriteLine($"{numOfEqualPeople} {numOfNotEqualPeople} {guys.Count}");
        }
    }
}


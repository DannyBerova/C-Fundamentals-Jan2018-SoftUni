using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        var people = new Dictionary<string, Person>();
        var input = Console.ReadLine();

        while (input != "End")
        {
            var inputTokens = input
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var personName = inputTokens[0];

            var currentPerson = new Person(personName);

            if (!people.ContainsKey(personName))
            {
                people[personName] = currentPerson;
            }

            var typeOfInfo = inputTokens[1];

            switch (typeOfInfo)
            {
                case "company":
                    var company = new Company(inputTokens[2], inputTokens[3], decimal.Parse(inputTokens[4]));
                    people[personName].Company = company;
                    break;
                case "car":
                    var car = new Car(inputTokens[2], int.Parse(inputTokens[3]));
                    people[personName].Car = car;
                    break;
                case "pokemon":
                    var pokemon = new Pokemon(inputTokens[2], inputTokens[3]);
                    people[personName].Pokemons.Add(pokemon);
                    break;
                case "parents":
                    var parent = new FamilyMember(inputTokens[2], inputTokens[3]);
                    people[personName].Parents.Add(parent);
                    break;
                case "children":
                    var child = new FamilyMember(inputTokens[2], inputTokens[3]);
                    people[personName].Children.Add(child);
                    break;
            }
            input = Console.ReadLine();
        }

        input = Console.ReadLine();

        Console.WriteLine(people[input]);
    }
}

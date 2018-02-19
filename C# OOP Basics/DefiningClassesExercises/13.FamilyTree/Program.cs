using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class StartUp
{
    public static void Main()
    {
        var people = new List<Person>();
        var searchedPersonParam = Console.ReadLine();

        while (true)
        {
            var input = Console.ReadLine();
            if (input == "End") break;

            if (input.Contains("-"))
            {
                var tokens = input
                            .Split(new[] { '-' }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(x => x.Trim())
                            .ToArray();
                var parentToken = tokens[0];
                var childToken = tokens[1];

                var parent = CreatePerson(parentToken);

                var child = CreatePerson(childToken);

                AddParentIfMissing(people, parent);

                if (parent.Name != null)
                {
                    people.FirstOrDefault(p => p.Name == parent.Name)
                          .AddChild(child);
                }
                else
                {
                    people.FirstOrDefault(p => p.Birthdate == parent.Birthdate)
                          .AddChild(child);
                }
            }
            else
            {
                var tokens = input
                            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var name = $"{tokens[0]} {tokens[1]}";
                var birthdate = tokens[2];
                var isExistingPerson = false;

                for (int i = 0; i < people.Count; i++)
                {
                    if (people[i].Name == name)
                    {
                        people[i].Birthdate = birthdate;
                        isExistingPerson = true;
                    }
                    if (people[i].Birthdate == birthdate)
                    {
                        people[i].Name = name;
                        isExistingPerson = true;
                    }
                    people[i].AddChildrenInfo(name, birthdate);
                }

                if (!isExistingPerson)
                {
                    people.Add(new Person(name, birthdate));
                }
            }
        }

        PrintParentsAndChildren(people, searchedPersonParam);
    }

    private static Person CreatePerson(string personParam)
    {
        var person = new Person();
        if (IsDate(personParam))
        {
            person.Birthdate = personParam;
        }
        else
        {
            person.Name = personParam;
        }
        return person;
    }

    private static void PrintParentsAndChildren(List<Person> people, string personParam)
    {
        Person person = people.FirstOrDefault(p => p.Birthdate == personParam ||
                                                   p.Name == personParam);
        var builder = new StringBuilder();

        builder.AppendLine($"{person.Name} {person.Birthdate}");

        builder.AppendLine("Parents:");
        people.Where(p => p.FindChild(person.Name) != null)
              .ToList()
              .ForEach(p => builder.AppendLine($"{p.Name} {p.Birthdate}"));

        builder.AppendLine("Children:");
        person.Children
              .ToList()
              .ForEach(c => builder.AppendLine($"{c.Name} {c.Birthdate}"));

        Console.WriteLine(builder);
    }

    private static void AddParentIfMissing(List<Person> people, Person parent)
    {
        if ((parent.Name != null && people.Any(p => p.Name == parent.Name)) ||
            (parent.Birthdate != null & people.Any(p => p.Birthdate == parent.Birthdate)))
        {
            return;
        }

        people.Add(parent);
    }

    public static bool IsDate(string s)
    {
        return s.Contains("/");
    }
}
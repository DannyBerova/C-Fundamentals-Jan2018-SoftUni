using System.Collections.Generic;
using System.Linq;

public class FamilyTreeBuilder
{
    public List<Person> FamilyTree { get; set; } 
    public Person MainPerson { get; set; }

    public FamilyTreeBuilder(string mainPersonInput)
    {
        FamilyTree = new List<Person>();
        MainPerson = Person.CreatePerson(mainPersonInput);
        FamilyTree.Add(MainPerson);
    }
    public void SetParentChildRelation(string parentInput, string childInput)
    {

        Person currentPerson = this.FamilyTree
            .FirstOrDefault(p => p.Birthday == parentInput || p.Name == parentInput);

        if (currentPerson == null)
        {
            currentPerson = Person.CreatePerson(parentInput);
            this.FamilyTree.Add(currentPerson);
        }

        SetChild( currentPerson, childInput);
    }

    private void SetChild( Person parent, string childInput)
    {
        var child = this.FamilyTree
            .FirstOrDefault(c => c.Name == childInput || c.Birthday == childInput);

        if (child == null)
        {
            child = Person.CreatePerson(childInput);
            this.FamilyTree.Add(child);
        }

        parent.Children.Add(child);
        child.Parents.Add(parent);
    }

    public void SetFullInfo( string name, string birthday)
    {
        var person = this.FamilyTree
                            .FirstOrDefault(p => p.Name == name || p.Birthday == birthday);
        if (person == null)
        {
            person = new Person();
            this.FamilyTree.Add(person);
        }
        person.Name = name;
        person.Birthday = birthday;
        CheckForDuplicate( name, birthday, person);
    }

    private void CheckForDuplicate( string name, string birthday, Person person)
    {
        Person duplicate = this.FamilyTree.Where(p => p.Name == name || p.Birthday == birthday)
                        .Skip(1)
                        .FirstOrDefault();

        if (duplicate != null)
        {
            RemoveDuplicate( person, duplicate);
        }
    }

    private void RemoveDuplicate( Person person, Person duplicate)
    {
        this.FamilyTree.Remove(duplicate);

        person.Parents.AddRange(duplicate.Parents);
        foreach (var parent in duplicate.Parents)
        {
            ReplaceDuplicate(person, duplicate, parent.Children);
        }

        person.Children.AddRange(duplicate.Children);
        foreach (var child in duplicate.Children)
        {
            ReplaceDuplicate(person, duplicate, child.Parents);
        }
    }

    private static void ReplaceDuplicate(Person original, Person duplicate, List<Person> collection)
    {
        int duplicateIndex = collection.IndexOf(duplicate);
        if (duplicateIndex > -1)
        {
            collection[duplicateIndex] = original;
        }
        else
        {
            collection.Add(original);
        }

    }


}


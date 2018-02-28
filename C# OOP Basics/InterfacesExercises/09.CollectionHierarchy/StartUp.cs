using System;

public class StartUp
{
    public static void Main()
    {
        var addCollection = new AddCollection<string>();
        var addRemoveCollection = new AddRemoveCollection<string>();
        var myList = new MyList<string>();

        var addIndicesAddCollection = String.Empty;
        var addIndicesAddRemoveCollection = String.Empty;
        var addIndicesMyList = String.Empty;

        var elements = Console.ReadLine().Split();

        int indexOfAdding;
        foreach (var element in elements)
        {
            indexOfAdding = addCollection.Add(element);
            addIndicesAddCollection += $"{indexOfAdding} ";

            indexOfAdding = addRemoveCollection.Add(element);
            addIndicesAddRemoveCollection += $"{indexOfAdding} ";

            indexOfAdding = myList.Add(element);
            addIndicesMyList += $"{indexOfAdding} ";
        }

        var amountOfRemoves = int.Parse(Console.ReadLine());

        var removedItemFromAddRemoveCollection = String.Empty;
        var removedItemFromMyList = String.Empty;

        var removedItem = string.Empty;
        for (int i = 0; i < amountOfRemoves; i++)
        {
            removedItem = addRemoveCollection.Remove();
            removedItemFromAddRemoveCollection += $"{removedItem} ";

            removedItem = myList.Remove();
            removedItemFromMyList += $"{removedItem} ";
        }

        Console.WriteLine(addIndicesAddCollection.TrimEnd());
        Console.WriteLine(addIndicesAddRemoveCollection.TrimEnd());
        Console.WriteLine(addIndicesMyList.TrimEnd());
        Console.WriteLine(removedItemFromAddRemoveCollection.TrimEnd());
        Console.WriteLine(removedItemFromMyList.TrimEnd());
    }
}


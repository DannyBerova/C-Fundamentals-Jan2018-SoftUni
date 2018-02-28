using System.Collections.Generic;
using System.Linq;

public class MyList<T> : IAddCollection<T>, IAddRemoveCollection<T>, IMyList<T>
{
    private List<T> dataSet;

    public MyList()
    {
        this.dataSet = new List<T>();
        this.Used = 0;
    }

    public int Used { get; private set; }

    public int Add(T element)
    {
        var indexOfAdding = 0;
        this.dataSet.Insert(indexOfAdding, element);
        this.Used++;
        return indexOfAdding;
    }

    public T Remove()
    {
        var removedItem = this.dataSet.FirstOrDefault();
        this.dataSet.RemoveAt(0);
        this.Used--;
        return removedItem;
    }
}
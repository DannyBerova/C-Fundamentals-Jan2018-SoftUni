using System.Collections.Generic;
using System.Linq;

public class AddRemoveCollection<T> : IAddCollection<T>, IAddRemoveCollection<T>
{
    private List<T> dataSet;

    public AddRemoveCollection()
    {
        this.dataSet = new List<T>();
    }

    public int Add(T element)
    {
        var indexOfAdding = 0;
        this.dataSet.Insert(indexOfAdding, element);
        return indexOfAdding;
    }

    public T Remove()
    {
        var removedItem = this.dataSet.LastOrDefault();
        this.dataSet.RemoveAt(this.dataSet.Count - 1);
        return removedItem;
    }
}
using System.Collections.Generic;

public class AddCollection<T> : IAddCollection<T>
{
    private List<T> dataSet;

    public AddCollection()
    {
        this.dataSet = new List<T>();
    }

    public int Add(T element)
    {
        var indexOfAdding = this.dataSet.Count;
        this.dataSet.Insert(indexOfAdding, element);
        return indexOfAdding;
    }
}
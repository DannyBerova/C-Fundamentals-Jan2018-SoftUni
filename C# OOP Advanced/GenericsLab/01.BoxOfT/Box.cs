using System.Collections.Generic;

public class Box<T>
{
    private readonly List<T> data;

    public Box()
    {
        this.data = new List<T>();
    }

    public IReadOnlyCollection<T> Data => this.data.AsReadOnly();

    public int Count => this.data.Count;

    public void Add(T element)
    {
        this.data.Add(element);
    }

    public T Remove()
    {
        T element = this.data[Count - 1];
        this.data.RemoveAt(this.data.Count - 1);

        return element;
    }
}


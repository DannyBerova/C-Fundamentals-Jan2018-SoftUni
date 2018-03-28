using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ListyIterator<T> : IEnumerable<T>
{
    private readonly List<T> data;

    public ListyIterator(params T[] data)
    {
        this.CurrentIndex = 0;
        this.data = new List<T>(data);
    }

    public int CurrentIndex { get; set; }

    public bool HasNext()
    {
        bool result = CurrentIndex < this.data.Count - 1;
        return result;
    }

    public bool Move()
    {
        if (!HasNext())
        {
            return false;
        }

        this.CurrentIndex++;
        return true;
    }

    public void Print()
    {
        if (!this.data.Any())
        {
            throw new InvalidOperationException("Invalid Operation!");
        }

        Console.WriteLine(this.data[CurrentIndex]);
    }

    public void PrintAll()
    {
        if (!this.data.Any())
        {
            throw new InvalidOperationException("Invalid Operation!");
        }

        Console.WriteLine(string.Join(" ", this.data));
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int index = 0; index < this.data.Count; index++)
        {
            yield return this.data[index];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}


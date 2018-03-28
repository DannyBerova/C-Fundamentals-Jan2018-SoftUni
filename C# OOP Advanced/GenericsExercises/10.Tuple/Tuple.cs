using System;
using System.Collections.Generic;
using System.Text;

namespace _10.Tuple
{
    public class Tuple<T, U>
{
    private T item1;
    private U item2;

    public Tuple(T item1, U item2)
    {
        this.Item1 = item1;
        this.Item2 = item2;
    }

    public T Item1
    {
        get { return item1; }
        set { item1 = value; }
    }

    public U Item2
    {
        get { return item2; }
        set { item2 = value; }
    }

    public override string ToString()
    {
        return $"{Item1} -> {Item2}";
    }
}
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class Lake : IEnumerable<int>
{
    private readonly List<int> data;

    public Lake(params int[] data)
    {
        this.data = new List<int>(data);
    }

    public IEnumerator<int> GetEnumerator()
    {
        for (int i = 0; i < data.Count; i+=2)
        {
            yield return this.data[i];
        }

        for (int i = data.Count - 1; i >= 0; i-=2)
        {
            if (this.data.Count % 2 == 1 && i == data.Count - 1)
            {
                i++;
                continue;
            }
            yield return this.data[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}


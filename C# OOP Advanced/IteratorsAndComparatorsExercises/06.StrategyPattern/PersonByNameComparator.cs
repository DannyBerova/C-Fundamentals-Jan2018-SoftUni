using System;
using System.Collections.Generic;
using System.Text;

public class PersonByNameComparator : IComparer<Person>
{
    public int Compare(Person x, Person y)
    {
        int result = x.Name.Length.CompareTo(y.Name.Length);
        if (result == 0)
        {
            var first = x.Name.ToLower()[0];
            var second = y.Name.ToLower()[0];
            result = first.CompareTo(second);
        }

        return result;
    }
}


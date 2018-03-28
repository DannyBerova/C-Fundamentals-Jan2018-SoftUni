using System.Collections.Generic;

public class PersonByAgeComparator : IComparer<Person>
{
    public int Compare(Person x, Person y)
    {
        int result = x.Age.CompareTo(y.Age);
        return result;
    }
}


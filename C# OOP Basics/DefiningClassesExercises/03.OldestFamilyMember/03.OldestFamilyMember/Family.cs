using System.Collections.Generic;
using System.Linq;

public class Family
{
    public List<Person> peoples;
    private bool isOrdered;

    public Family()
    {
        peoples = new List<Person>();
        isOrdered = false;
    }

    public void AddMember(Person member)
    {
        peoples.Add(member);
        isOrdered = false;
    }

    public Person GetOldestMember()
    {
        if (!isOrdered)
        {
            isOrdered = true;
            return peoples.OrderByDescending(a => a.Age).FirstOrDefault();
        }

        return peoples[0];
    }
}


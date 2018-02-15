using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Family
{
    public List<Person> familyList;

    public Family()
    {
        familyList = new List<Person>();
    }

    public void AddMember(Person member)
    {
        familyList.Add(member);
    }

    public Person GetOldestMember()
    {
        return familyList.OrderByDescending(x => x.Age).First();
    }
}


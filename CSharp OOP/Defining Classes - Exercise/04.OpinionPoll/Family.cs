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

    public List<Person> GetOverThirty()
    {
        return familyList.Where(x => x.Age > 30).ToList();
    }
}

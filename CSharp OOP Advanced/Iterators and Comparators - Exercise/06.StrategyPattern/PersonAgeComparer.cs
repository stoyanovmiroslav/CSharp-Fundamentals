using System;
using System.Collections.Generic;
using System.Text;

public class PersonAgeComparer : IComparer<Person>
{
    public int Compare(Person x, Person y)
    {
        int result = x.Age.CompareTo(y.Age);

        if (result == 0)
        {
            result = x.Name[0].CompareTo(y.Name[0]);
        }

        return result;
    }
}
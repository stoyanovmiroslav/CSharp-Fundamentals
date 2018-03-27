using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Sorter<T>
                   where T : IComparable<T>
{
    public static List<T> Sort(List<T> colection)
    {
        List<T> orderedList = colection.OrderBy(x => x).ToList();
        return orderedList;
    }
}
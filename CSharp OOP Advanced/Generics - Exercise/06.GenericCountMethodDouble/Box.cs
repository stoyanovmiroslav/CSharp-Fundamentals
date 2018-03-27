using System;
using System.Collections.Generic;
using System.Text;

public class Box<T>
             where T : IComparable
{

    public int GreaterElements(List<T> elements, T element)
    {
        int count = 0;

        foreach (var currentElement in elements)
        {
            if (currentElement.CompareTo(element) > 0)
            {
                count++;
            }
        }

        return count;
    }
}
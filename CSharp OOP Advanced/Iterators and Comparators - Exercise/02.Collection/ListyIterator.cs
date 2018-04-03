using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class ListyIterator<T> : IEnumerable<T>
{
    private List<T> elements;
    private int currentIndex = 0;

    public ListyIterator(List<T> elements)
    {
       this.elements = new List<T>(elements);
    }

    public bool Move()
    {
        this.currentIndex++;
        if (currentIndex >= this.elements.Count)
        {
            currentIndex--;
            return false;
        }

        return true;
    }

    public bool HasNext()
    {
        if (currentIndex < this.elements.Count - 1)
        {
            return true;
        }

        return false;
    }

    public string Print()
    {
        if (elements.Count <= 0)
        {
            return "Invalid Operation!";
        }
       return elements[currentIndex].ToString();
    }

    public void Create(List<T> elements)
    {
        this.elements.AddRange(elements);
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < this.elements.Count; i++)
        {
            yield return this.elements[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
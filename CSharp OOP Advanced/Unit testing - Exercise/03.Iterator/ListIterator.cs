using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

public class ListIterator<T>
{
    private List<T> elements;
    private int currentIndex = 0;

    public ListIterator(ICollection<T> elements)
    {
        this.NullValidation(elements);
        this.elements = new List<T>(elements);
    }

    private void NullValidation(ICollection<T> collection)
    {
        if (collection == null)
        {
            throw new ArgumentNullException();
        }
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
            throw  new  InvalidOperationException("Invalid Operation!");
        }
       return elements[currentIndex].ToString();
    }

    public void Create(List<T> elements)
    {
        this.elements.AddRange(elements);
    }
}
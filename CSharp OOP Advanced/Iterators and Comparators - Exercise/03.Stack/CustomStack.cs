using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CustomStack<T> : IEnumerable<T>
{
    private List<T> elements;

    public CustomStack()
    {
        this.elements = new List<T>();
    }

    public int Count => this.elements.Count;

    public void Push(List<T> element)
    {
        this.elements.AddRange(element);
    }

    public T Pop()
    {
        if (elements.Count > 0)
        {
            T element = elements.Last();
            elements.RemoveAt(elements.Count - 1);
            return element;
        }

        return default(T);

    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = elements.Count - 1; i >= 0; i--)
        {
            yield return elements[i];
        }

        for (int i = elements.Count - 1; i >= 0; i--)
        {
            yield return elements[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
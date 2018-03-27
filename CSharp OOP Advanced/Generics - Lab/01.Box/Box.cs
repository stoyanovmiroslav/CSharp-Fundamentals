using System;
using System.Collections.Generic;
using System.Text;

public class Box<T>
{
    private List<T> items;

    public Box()
    {
        this.items = new List<T>();
    }

    public int Count => items.Count;

    public void Add(T element)
    {
        items.Add(element);
    }

    public T Remove()
    {
        T item = items[items.Count - 1];
        items.RemoveAt(items.Count - 1);
        return item;
    }
}
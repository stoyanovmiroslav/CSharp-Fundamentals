using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CustomList<T>
              where T : IComparable<T>
{
    private List<T> elements;

    public CustomList()
    {
        this.elements = new List<T>();
    }


    public void Add(T element)
    {
        this.elements.Add(element);
    }

    public T Remove(int index)
    {
        T removedElement = this.elements[index];
        this.elements.RemoveAt(index);
        return removedElement;
    }

    public bool Contains(T element)
    {
        if (this.elements.Contains(element))
        {
            return true;
        }

        return false;
    }

    public void Swap(int index1, int index2)
    {
        T firstElemet = this.elements[index1];
        T secondElemet = this.elements[index2];

        this.elements[index1] = secondElemet;
        this.elements[index2] = firstElemet;
    }

    public int CountGreaterThan(T element)
    {
        int count = 0;

        foreach (var currentElement in this.elements)
        {
            if (currentElement.CompareTo(element) > 0)
            {
                count++;
            }
        }

        return count;
    }

    public T Max()
    {
        T maxElement = this.elements.Max();
        return maxElement;
    }

    public T Min()
    {
        T minElement = this.elements.Min();
        return minElement;
    }

    public override string ToString()
    {
        return string.Join(Environment.NewLine, elements);
    }
}
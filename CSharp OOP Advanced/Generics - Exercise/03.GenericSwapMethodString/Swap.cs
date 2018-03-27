using System;
using System.Collections.Generic;
using System.Text;

public class Swap<T>
{
    private List<T> elements;

    public Swap(List<T> elements)
    {
        this.elements = elements;
    }

    public List<T> SwapElements(int[] indexes)
    {
        T firstElemet = elements[indexes[0]];
        T secondElemet = elements[indexes[1]];

        elements[indexes[0]] = secondElemet;
        elements[indexes[1]] = firstElemet;
        return elements;
    }
}
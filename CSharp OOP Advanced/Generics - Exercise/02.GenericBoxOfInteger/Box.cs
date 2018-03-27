using System;
using System.Collections.Generic;
using System.Text;

public class Box<T>
{
    private T storedValue;
    private List<T> elements;

    public Box(T storedValue)
    {
        this.storedValue = storedValue;
    }

    public override string ToString()
    {
        string result = $"{this.storedValue.GetType().FullName}: {this.storedValue}";
        return result;
    }
}
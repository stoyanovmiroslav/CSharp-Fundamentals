using System;
using System.Collections.Generic;
using System.Text;


public class StackOfStrings
{
    private List<string> Stack { get; set; }

    public StackOfStrings()
    {
        this.Stack = new List<string>(); 
    }

    public void Push(string item)
    {
        Stack.Add(item);
    }

    public string Pop()
    {
        string result = null;
        if (Stack.Count > 0)
        {
            result = Stack[Stack.Count - 1];
            Stack.RemoveAt(Stack.Count - 1);
        }
        return result;
    }

    public string Peek()
    {
        string result = null;
        if (Stack.Count > 0)
        {
            result = Stack[Stack.Count - 1];
        }
        return result;
    }

    public bool IsEmpty()
    {
        bool isEmpty = true;

        if (Stack.Count > 0)
        {
            isEmpty = false;
        }
        return isEmpty;
    }
}
using System;
using System.Collections.Generic;
using System.Text;

public class SimpleLayout : ILayout
{
    const string Format = "{0} - {1} - {2}";

    public string FormatError(IError error)
    {
        string result = string.Format(Format, error.DateTime, error.Level.ToString(), error.Message);
        return result;
    }
}
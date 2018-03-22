using System;
using System.Collections.Generic;
using System.Text;

public class XmlLayout : ILayout
{
    private string Format = "<log>" + Environment.NewLine +
                     "\t<date>{0}</date>" + Environment.NewLine +
                     "\t<level>{1}</level>" + Environment.NewLine + 
                     "\t<message>{2}</message>" + Environment.NewLine +
                      "</log>";

    public string FormatError(IError error)
    {
        string result = string.Format(Format, error.DateTime, error.Level.ToString(), error.Message);
        return result;
    }
}
using System;
using System.Collections.Generic;
using System.Text;

public class Error : IError
{
    public Error(string dateTime, ErrorLevel level, string message)
    {
        this.DateTime = dateTime;
        this.Level = level;
        this.Message = message;
    }

    public string DateTime { get; }

    public string Message { get; }

    public ErrorLevel Level { get; }
}
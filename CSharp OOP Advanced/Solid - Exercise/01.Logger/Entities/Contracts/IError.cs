using System;
using System.Collections.Generic;
using System.Text;

public interface IError 
{
    string DateTime { get; }

    string Message { get; }

    ErrorLevel Level { get; }
}
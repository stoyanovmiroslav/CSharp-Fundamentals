using System;
using System.Collections.Generic;
using System.Text;

public class ErrorFactory
{
    public IError CreateErrorFactory(string dateTime, string errorLevelString, string message)
    {
        ErrorLevel errorLevel = ParseErrorLevel(errorLevelString);
        IError error = new Error(dateTime, errorLevel, message);
        return error;
    }

    private ErrorLevel ParseErrorLevel(string levelString)
    {
        try
        {
            object levelObj = Enum.Parse(typeof(ErrorLevel), levelString);
            return (ErrorLevel)levelObj;
        }
        catch (ArgumentException e)
        {
            throw new ArgumentException("Invalid ErrorLevel Tyep!", e.Message);
        }
    }
}
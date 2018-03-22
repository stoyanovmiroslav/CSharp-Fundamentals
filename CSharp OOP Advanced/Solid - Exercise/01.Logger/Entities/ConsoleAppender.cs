using System;
using System.Collections.Generic;
using System.Text;

public class ConsoleAppender : IAppender
{
    public ConsoleAppender(ILayout layout, ErrorLevel errorLevel)
    {
        this.Layout = layout;
        this.ErrorLevel = errorLevel;
    }
    
    public int MessagesAppended { get; private set; }

    public ILayout Layout { get; }

    public ErrorLevel ErrorLevel { get; }

    public void Append(IError error)
    {
        string formattedError = this.Layout.FormatError(error);
        Console.WriteLine(formattedError);
        this.MessagesAppended++;
    }

    public override string ToString()
    {
        string result = $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report level: {this.ErrorLevel.ToString()}, Messages appended: {this.MessagesAppended}";
        return result;
    }
}
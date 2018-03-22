using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

public class FileAppender : IAppender
{
    private ILogFile logFile; 

    public FileAppender(ILayout layout, ErrorLevel errorLevel, ILogFile logFile)
    {
        this.Layout = layout;
        this.ErrorLevel = errorLevel;
        this.logFile = logFile;
    }

    public ILayout Layout { get; }

    public int MessagesAppended { get; private set; }

    public ErrorLevel ErrorLevel { get; }

    public void Append(IError error)
    {
        string formattedError = this.Layout.FormatError(error);
        this.logFile.WriteToFile(formattedError);
        this.MessagesAppended++;
    }

    public override string ToString()
    {
        string result = $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report level: {this.ErrorLevel.ToString()}, Messages appended: {this.MessagesAppended}, File size: {logFile.Size}";
        return result;
    }
}
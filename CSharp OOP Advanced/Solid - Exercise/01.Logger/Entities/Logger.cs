using System;
using System.Collections.Generic;
using System.Text;

public class Logger : ILogger
{
    IEnumerable<IAppender> appenders;

    public IReadOnlyCollection<IAppender> Appenders => (IReadOnlyCollection<IAppender>)this.appenders;

    public Logger(IEnumerable<IAppender> appenders)
    {
        this.appenders = appenders;
    }

    public void Log(IError error)
    {
        foreach (var apender in this.appenders)
        {
            if (apender.ErrorLevel <= error.Level)
            {
                apender.Append(error);
            }
        }
    }
}
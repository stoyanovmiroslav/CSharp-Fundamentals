using System;
using System.Collections.Generic;
using System.Text;

public interface IAppender
{
    void Append(IError error);

    ErrorLevel ErrorLevel { get; }

    ILayout Layout { get; }
}
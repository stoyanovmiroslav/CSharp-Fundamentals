using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

public class LogFile : ILogFile
{
    const string defaultPath = "../";
    public LogFile(string fileName)
    {
        this.Path = defaultPath + fileName;
        this.Size = 0;

    }

    public string Path { get; }

    public int Size { get; private set; }

    public void WriteToFile(string errorLog)
    {
        File.AppendAllText(this.Path, errorLog + Environment.NewLine);

        int addedSize = 0;

        foreach (var letter in errorLog.Where(c => char.IsLetter(c)))
        {
            addedSize += letter;
        }
        this.Size += addedSize;
    }
}
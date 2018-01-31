using System;
using System.IO;

namespace _02._Line_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader streamReader = new StreamReader("../Resource/text.txt"))
            {
                using (StreamWriter streamWriter = new StreamWriter("../Resource/newText.txt"))
                {
                    string readLine = "";
                    int countLine = 1;
                    while ((readLine = streamReader.ReadLine()) != null)
                    {
                        streamWriter.WriteLine("Line {0}: {1}", countLine, readLine);
                        countLine++;
                    }
                }
            }
        }
    }
}

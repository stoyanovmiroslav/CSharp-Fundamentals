using System;
using System.IO;

namespace _01._Odd_Lines
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader streamRead = new StreamReader("../Resource/text.txt"))
            {
                string line = streamRead.ReadLine();
                int count = 0;
                while (line != null)
                {
                    if (count % 2 != 0)
                    {
                        Console.WriteLine(line);
                    }
                    count++;
                    line = streamRead.ReadLine();
                }
            }
        }
    }
}

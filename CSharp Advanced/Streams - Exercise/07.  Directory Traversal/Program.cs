using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _07.__Directory_Traversal
{
    class Program
    {
        static void Main(string[] args)
        {
            string directory = Console.ReadLine();
            DirectoryInfo di = new DirectoryInfo(directory);
            var dict = new Dictionary<string, Dictionary<string, double>>();

            foreach (var fi in di.GetFiles())
            {
                if (!dict.ContainsKey(fi.Extension))
                {
                    dict.Add(fi.Extension, new Dictionary<string, double>());
                }
                else
                {
                    double length = fi.Length / 1024.0;
                    dict[fi.Extension].Add(fi.Name, length);
                }
            }

            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            using (var streamWriter = new StreamWriter(path + "/report.txt"))
          {
                foreach (var extesion in dict.OrderByDescending(x => x.Value.Values.Count).ThenBy(x => x.Key))
                {
                    streamWriter.WriteLine(extesion.Key);
                    foreach (var files in extesion.Value.OrderBy(x => x.Value))
                    {
                        streamWriter.WriteLine("--{0} - {1}kb", files.Key, files.Value);
                    }
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _10._The_Heigan_Dance
{
    class Program
    {
        static void Main()
        {
            var dict = new Dictionary<int, List<string>>();
            var dict2 = new Dictionary<int,Dictionary<string,List<string>>>();

            dict.Add(2, new List<string>());
            dict[2].Add("sdada");

            dict2.Add(2, new Dictionary<string, List<string>>());
            dict2[2].Add("dict222", new List<string>());
            dict2[2]["dict222"].Add("sadasd");
            dict2[2]["dict222"].Add("aaaaaaa");

            Console.WriteLine();
        }

    }
}
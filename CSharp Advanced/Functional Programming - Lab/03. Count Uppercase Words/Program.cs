using System;
using System.Linq;

namespace _03._Count_Uppercase_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine()
                       .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                       .Where(d => char.IsUpper(d[0]))
                       .ToList()
                       .ForEach(d => Console.WriteLine(d));
                        
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._The_Party_Reservation_Filter_Module
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList();
            string commands = null;
            List<string> removedNames = new List<string>();

            while ((commands = Console.ReadLine()) != "Print")
            {
                string[] splitCommand = commands.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                string addOrRemove = splitCommand[0];
                string content = splitCommand[2];


                Func<string, bool> startFunc = n => n.StartsWith(content);
                Func<string, bool> endFunc = n => n.EndsWith(content);
                Func<string, bool> lengthFunc = n => n.Length == int.Parse(content);
                Func<string, bool> containsFunc = n => n.Contains(content);

                switch (splitCommand[1])
                {
                    case "Starts with":
                        Filter(names, removedNames, addOrRemove, startFunc);
                        break;
                    case "Ends with":
                        Filter(names, removedNames, addOrRemove, endFunc);
                        break;
                    case "Length":
                        Filter(names, removedNames, addOrRemove, lengthFunc);
                        break;
                    case "Contains":
                        Filter(names, removedNames, addOrRemove, containsFunc);
                        break;
                }
            }
            Console.WriteLine(string.Join(" ", names));
        }

        private static void Filter(List<string> names, List<string> removedNames, string addOrRemove, Func<string, bool> func)
        {


            if (addOrRemove == "Add filter")
            {
                for (int i = 0; i < names.Count; i++)
                {
                    if (func(names[i]))
                    {
                        removedNames.Add(names[i]);
                        names.RemoveAt(i);
                        i--;
                    }
                }
            }
            else if (addOrRemove == "Remove filter")
            {
                for (int i = 0; i < removedNames.Count; i++)
                {
                    if (func(removedNames[i]))
                    {
                        names.Add(removedNames[i]);
                        removedNames.RemoveAt(i);
                        i--;
                    }
                }
            }
        }
    }
}

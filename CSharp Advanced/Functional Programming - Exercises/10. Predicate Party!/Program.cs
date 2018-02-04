using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._Predicate_Party_
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList();
            string command = null;

            while ((command = Console.ReadLine()) != "Party!")
            {
                string[] splitCommand = command.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                Func<string, bool> criteria = name => CheckCriteria(name, names, splitCommand[1], splitCommand[2]);

                switch (splitCommand[0])
                {
                    case "Remove":
                        names = names.Where(n => !criteria(n)).ToList();
                        break;

                    case "Double":
                        List<string> doubleNames = new List<string>();
                        for (int i = 0; i < names.Count; i++)
                        {
                            doubleNames.Add(names[i]);
                            if (criteria(names[i]))
                            {
                                doubleNames.Add(names[i]);
                            }
                        }
                        names = doubleNames.ToList();
                        break;

                        //List<string> doubleNames = names.Where(check).ToList();
                        // if(doubleNames != null)
                        // names.AddRange(doubleNames);
                        // break;
                }
            }

            if (names.Count > 0)
            {
                Console.WriteLine("{0} are going to the party!", String.Join(", ", names));
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }

        private static bool CheckCriteria(string name, List<string> names, string operation, string content)
        {
            switch (operation)
            {
                case "StartsWith":
                    return name.StartsWith(content);
                case "EndsWith":
                    return name.EndsWith(content);
                case "Length":
                    return name.Length == int.Parse(content);
                default:
                    return false;
            }
        }
    }
}


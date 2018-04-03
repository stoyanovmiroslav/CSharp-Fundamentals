using System;
using System.Linq;
using System.Reflection;

namespace _08.CreateCustomClassAttribute
{
    [Custom("Pesho", 3, "Used for C# OOP Advanced Course - Enumerations and Attributes.", "Pesho", "Svetlio")]
    public class StartUp
    {
        static void Main(string[] args)
        {
            var type = typeof(StartUp);
            CustomAttribute attr = (CustomAttribute)type.GetCustomAttributes().First();

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "END")
            {
                switch (command)
                {
                    case "Author":
                        Console.WriteLine($"Author: {attr.Author}");
                        break;
                    case "Revision":
                        Console.WriteLine($"Revision: {attr.Revision}");
                        break;
                    case "Description":
                        Console.WriteLine($"Class description: {attr.Description}");
                        break;
                    case "Reviewers":
                        Console.WriteLine($"Reviewers: {string.Join(", ", attr.Reviewers)}");
                        break;
                    default:
                        break;
                }
            }
        }
    }
}

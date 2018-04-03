using System;
using System.Linq;
using System.Reflection;

public class HarvestingFieldsTest
{
    public static void Main()
    {
        string command = string.Empty;
        while ((command = Console.ReadLine()) != "HARVEST")
        {
            var typeClass = typeof(HarvestingFields);
            var fields = typeClass.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

            switch (command)
            {
                case "protected":
                    PrintFields(fields.Where(f => f.IsFamily).ToArray());
                    break;
                case "private":
                    PrintFields(fields.Where(f => f.IsPrivate).ToArray());
                    break;
                case "public":
                    PrintFields(fields.Where(f => f.IsPublic).ToArray());
                    break;
                case "all":
                    PrintFields(fields);
                    break;
            }
        }
    }

    private static void PrintFields(FieldInfo[] fields)
    {
        foreach (var field in fields)
        {
            string accessModifier = field.IsFamily ? "protected" : field.Attributes.ToString().ToLower();
            Console.WriteLine($"{accessModifier} {field.FieldType.Name} {field.Name}");
        }
    }
}

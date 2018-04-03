using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string StealFieldInfo(string className, params string[] namesOfFilds)
    {
        var classType = Type.GetType(className);
        var fields = classType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);

        StringBuilder sb = new StringBuilder();

        var classIstance = Activator.CreateInstance(classType, new object[] { });
        sb.AppendLine($"Class under investigation: {className}");

        foreach (var field in fields.Where(f => namesOfFilds.Contains(f.Name)))
        {
            sb.AppendLine($"{field.Name} = {field.GetValue(classIstance)}");
        }

        return sb.ToString().Trim();
    }

    public string AnalyzeAcessModifiers(string className)
    {
        var classType = Type.GetType(className);
        var fields = classType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
        var properties = classType.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

        StringBuilder sb = new StringBuilder();


        foreach (var field in fields)
        {
            sb.AppendLine($"{field.Name} must be private!");
        }

        foreach (var property in properties)
        {
            if (property.GetMethod?.IsPrivate == true)
            sb.AppendLine($"{property.GetMethod.Name} have to be public!");
        }

        foreach (var property in properties)
        {
            if (property.SetMethod?.IsPublic == true)
                sb.AppendLine($"{property.SetMethod.Name} have to be private!");
        }

        return sb.ToString().Trim();
    }
}
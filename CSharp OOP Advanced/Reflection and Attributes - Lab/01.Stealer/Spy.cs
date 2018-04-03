using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string StealFieldInfo(string nameOfClass, params string[] namesOfFilds)
    {
        var classType = Type.GetType(nameOfClass);
        var fields = classType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);

        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Class under investigation: {nameOfClass}");

        var classIstance = Activator.CreateInstance(classType, new object[] { });

        foreach (var field in fields.Where(f => namesOfFilds.Contains(f.Name)))
        {
            sb.AppendLine($"{field.Name} = {field.GetValue(classIstance)}");
        }

        return sb.ToString().Trim();
    }
}
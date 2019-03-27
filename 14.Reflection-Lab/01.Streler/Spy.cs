using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string StealFieldInfo(string nameOfClass, params string[] fields)
    {
        StringBuilder answer = new StringBuilder();

        Type type = Type.GetType($"{nameOfClass}");
        FieldInfo[] fieldsInClass = type
        .GetFields(BindingFlags.Instance 
        | BindingFlags.Static
        | BindingFlags.NonPublic
        | BindingFlags.Public);
        Object classInstance = Activator.CreateInstance(type, new object[] { });
        answer.AppendLine($"Class under investigation: {nameOfClass}");

        foreach (var field in fieldsInClass.Where(x => fields.Contains(x.Name)))
        {
            answer.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
        }

        return answer.ToString().Trim();
    }
}


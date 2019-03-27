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

    public string AnalyzeAcessModifiers(string className)
    {
        var result = new StringBuilder();
        Type type = Type.GetType(className);

        FieldInfo[] fields = type
            .GetFields(BindingFlags.Instance
            | BindingFlags.Public
            | BindingFlags.Static);
        MethodInfo[] publicMethods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public);
        MethodInfo[] nonPublicMethods = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

        foreach (var field in fields)
        {
            result.AppendLine($"{field.Name} must be private!");
        }

        foreach (var method in nonPublicMethods.Where(x => x.Name.StartsWith("get")))
        {
            result.AppendLine($"{method.Name} have to be public!");
        }

        foreach (var method in publicMethods.Where(x => x.Name.StartsWith("set")))
        {
            result.AppendLine($"{method.Name} have to be private!");
        }

        return result.ToString();
    }

    public string RevealPrivateMethods(string className)
    {
        var result = new StringBuilder();
        result.AppendLine($"All Private Methods of Class: {className}");
        Type type = Type.GetType(className);
        result.AppendLine($"Base Class: {type.BaseType.Name}");

        MethodInfo[] privateMethods = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

        foreach (var method in privateMethods)
        {
            result.AppendLine(method.Name);
        }

        return result.ToString().Trim();
    }
}


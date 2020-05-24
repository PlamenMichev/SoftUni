using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public class Tracker
{
    public void PrintMethodsByAuthor()
    {
        var type = typeof(StartUp);
        var result = new StringBuilder();

        var methods = type
            .GetMethods(BindingFlags.Instance 
            | BindingFlags.Public 
            | BindingFlags.NonPublic 
            | BindingFlags.Static)
            .Where(x => x.CustomAttributes.Any(n => n.AttributeType == typeof(AuthorAttribute)));

        foreach (var method in methods)
        {
            var attributes = method.GetCustomAttributes();
            foreach (AuthorAttribute attribute in attributes)
            {
                Console.WriteLine($"{method.Name} is written by {attribute.Name}");
            }
        }
    }
}


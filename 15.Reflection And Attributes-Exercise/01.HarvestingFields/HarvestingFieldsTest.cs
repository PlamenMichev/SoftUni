 namespace P01_HarvestingFields
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            string command = Console.ReadLine();
            while (command != "HARVEST")
            {
                Type type = typeof(HarvestingFields);
                FieldInfo[] fields = type
                    .GetFields(BindingFlags.Instance 
                    | BindingFlags.NonPublic
                    | BindingFlags.Public
                    | BindingFlags.Static);

                if (command == "private")
                {
                    foreach (var field in fields.Where(f => f.IsPrivate))
                    {
                        Console.WriteLine($"private {field.FieldType.Name} {field.Name}");
                    }
                }
                else if (command == "protected")
                {
                    foreach (var field in fields.Where(f => f.IsFamily))
                    {
                        Console.WriteLine($"protected {field.FieldType.Name} {field.Name}");
                    }
                }
                else if (command == "public")
                {
                    foreach (var field in fields.Where(f => f.IsPublic))
                    {
                        Console.WriteLine($"public {field.FieldType.Name} {field.Name}");
                    }
                }
                else if (command == "all")
                {
                    foreach (var field in fields)
                    {
                        if (field.Attributes.ToString().ToLower() == "family")
                        {
                            Console.WriteLine($"protected {field.FieldType.Name} {field.Name}");

                        }
                        else
                        {
                            Console.WriteLine($"{(field.Attributes).ToString().ToLower()} " +
                                $"{field.FieldType.Name} {field.Name}");
                        }
                    }
                }

                command = Console.ReadLine();
            }
        }
    }
}

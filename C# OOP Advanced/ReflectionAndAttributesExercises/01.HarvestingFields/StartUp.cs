using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class StartUp
{
    public static void Main()
    {
        Type classType = typeof(HarvestingFields);
        var fields = classType
            .GetFields
            (BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);

        string input;

        while ((input = Console.ReadLine()) != "HARVEST")
        {
            switch (input)
            {
                case "private":
                    var privateFields = fields.Where(f => f.IsPrivate);
                    PrintSearchedFields(privateFields, input);
                    break;
                case "protected":
                    var protectedFields = fields.Where(f => f.IsFamily);
                    PrintSearchedFields(protectedFields, input);
                    break;
                case "public":
                    var publicFields = fields.Where(f => f.IsPublic);
                    PrintSearchedFields(publicFields, input);
                    break;
                case "all":
                    PrintSearchedFields(fields, input);
                    break;

                default:
                    break;
            }
        }

    }

    public static void PrintSearchedFields(IEnumerable<FieldInfo> searchedFields, string command)
    {
        foreach (var field in searchedFields)
        {
            var acessModifier = field.Attributes.ToString().ToLower() == "family" ? "protected" : field.Attributes.ToString().ToLower();
            Console.WriteLine($"{acessModifier} {field.FieldType.Name} {field.Name}");
        }
    }
}


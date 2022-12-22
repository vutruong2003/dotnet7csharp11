using System.Text;

namespace CSharpEleven.StringLiterals;

public  class StringLiteral : IExample
{
    public static int Order => 5;

    public static string Name => "String Literal";

    public static string Description => "String Literal";

    public static void Execute()
    {
        // Normal way: use the '\' for special chars
        var xml = "<?xml version=\"1.0\" enconding=\"UTF-8\" ?>";

        // Normal way: use the @ for special chars
        var xml2 = @"<?xml version=""1.0"" enconding=""UTF-8"" ?>";

        // New 
        var xml3 = """"<?xml version=""1.0"" enconding="UTF-8" ?>"""";
        
        var version = "1.0";
        var xml4 = $$"""<?xml version="{{{version}}}" enconding="UTF-8" ?>""";

        Console.WriteLine("Normal approach: ");
        Console.WriteLine(xml);
        Console.WriteLine();

        Console.WriteLine("Use @: ");
        Console.WriteLine(xml2);
        Console.WriteLine();

        Console.WriteLine("String literal: ");
        Console.WriteLine(xml3);
        Console.WriteLine();

        Console.WriteLine("String literal and interpolation: ");
        Console.WriteLine(xml4);
        Console.WriteLine();

        Console.WriteLine("String with new line");
        // Normal way
        var json = "{\n    \"name\": \"Vu Truong\"\n}";

        // String Literal
        var json2 = """
        {
            "name": "Vu Truong"
        }
        """;

        // String Literal with interpolation
        var name = "Vu Truong";

        var json3 = $$"""
            {
                "name": "{{name}}"
            }
            """;

        Console.WriteLine("Normal approach: ");
        Console.WriteLine(json);
        Console.WriteLine();

        Console.WriteLine("String literal: ");
        Console.WriteLine(json2);
        Console.WriteLine();

        Console.WriteLine("String Literal with interpolation: ");
        Console.WriteLine(json3);
    }
}

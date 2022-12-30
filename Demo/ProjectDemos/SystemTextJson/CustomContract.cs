using System.Text.Json;
using System.Text.Json.Serialization.Metadata;

namespace SystemTextJson;

public class CustomContract
{
    public static void Execute()
    {
        Console.WriteLine("Demo custom contract: ");
        var serializerOptions = new JsonSerializerOptions
        {
            TypeInfoResolver = new PropertyContractResolver()
        };

        var objText = JsonSerializer.Serialize(new { value = 44 }, serializerOptions);
        Console.WriteLine(objText);

        Console.WriteLine();
        Console.WriteLine();
    }
}

public class PropertyContractResolver : DefaultJsonTypeInfoResolver
{
    public override JsonTypeInfo  GetTypeInfo(Type t, JsonSerializerOptions o)
    {
        JsonTypeInfo type = base.GetTypeInfo(t, o);

        if (type.Kind == JsonTypeInfoKind.Object)
        {
            foreach (JsonPropertyInfo prop in type.Properties)
            {
                prop.Name = prop.Name.ToUpperInvariant();
            }
        }

        return type;
    }
}
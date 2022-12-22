using System.ComponentModel;

namespace CSharpEleven.MinorChanges;

internal class NameAttribute : Attribute
{
    public NameAttribute(string name)
    {

    }
}

internal class ExtenedNameOf
{
    [DisplayName(nameof(name))]
    public void Update(string name)
    {
        var expr = ([Name(nameof(cost))] int cost) => Console.WriteLine(cost);
    }

    [Name(nameof(T))]
    public void Info<T>(T name)
    {
        
    }
}

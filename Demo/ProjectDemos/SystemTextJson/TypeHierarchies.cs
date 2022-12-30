using System.Text.Json;
using System.Text.Json.Serialization;

namespace SystemTextJson;

public class CustomJsonDerivedTypeAttribute<T> : JsonDerivedTypeAttribute 
{
    public CustomJsonDerivedTypeAttribute() : base(typeof(T))
    {
    }

    public CustomJsonDerivedTypeAttribute(int typeDiscriminator) : base(typeof(T), typeDiscriminator)
    {
    }

    public CustomJsonDerivedTypeAttribute(string typeDiscriminator) : base(typeof(T), typeDiscriminator)
    {
    }
}

[JsonDerivedType(typeof(Employee), "Developer")]
public class Person
{
    public string Name { get; set; } = null!;

    public int Age { get; set; }

    public virtual void Update(Person other)
    {
        Name = other.Name;
        Age = other.Age;
    }
}

[JsonPolymorphic(TypeDiscriminatorPropertyName = "$Position")]
[CustomJsonDerivedTypeAttribute<Leader>("Boss")]
public class Employee : Person
{
    public int Level { get; set; }

    public string PrimarySkill { get; set; } = null!;
    
    public override void Update(Person other)
    {
        base.Update(other);

        if (other is Employee emp)
        {
            Level = emp.Level;
            PrimarySkill = emp.PrimarySkill;
        }
    }
}

public class Leader : Employee
{
    public string Team { get; set; } = null!;
}

public static class TypeHierarchies
{
    public static void Execute()
    {
        Console.WriteLine("Demo type hierarchies: ");

        var emp = new Person { Name = "Tai Vo", Age = 18 };

        Person developer = new Employee { Level = 5, PrimarySkill = ".NET" };
        developer.Update(emp);

        Employee leader = new Leader { Team = ".NET" };
        leader.Update(developer);

        var empJson = JsonSerializer.Serialize(emp);
        var devJson = JsonSerializer.Serialize(developer);
        var leaderJson = JsonSerializer.Serialize(leader);

        Console.WriteLine($"Employee: {empJson}");
        Console.WriteLine($"Developer: {devJson}");
        Console.WriteLine($"Leader: {leaderJson}");

        Console.WriteLine();
        Console.WriteLine();
    }
}
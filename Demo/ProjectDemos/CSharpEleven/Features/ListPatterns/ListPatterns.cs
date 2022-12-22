namespace CSharpEleven.Features;

public class ListPatterns : IExample
{
    public static int Order => 1;

    public static string Name => "List Pattern";

    public static string Description => "List Pattern";

    public static void Execute()
    {
        var numbers = new int[] { 1, 2, 5 };
        Console.WriteLine("Test numbers: { 1, 2, 5 }");

        Console.WriteLine($"Numbers is [1, 2, 5]: {numbers is [1, 2, 5]}");
        Console.WriteLine($"Numbers is [1, 2, 2]: {numbers is [1, 2, 2]}");
        Console.WriteLine($"Numbers is numbers is [1, 2, 2, 3, 5]: {numbers is [1, 2, 2, 3, 5]}");
        Console.WriteLine($"Numbers is numbers is [1, 2, ..]: {numbers is [1, 2, ..]}");
        Console.WriteLine($"Numbers is numbers is  [.., 2, 5]: {numbers is  [.., 2, 5]}");
        Console.WriteLine($"Numbers is numbers is [.., 4]: {numbers is [.., 4]}");

        Console.WriteLine($"Numbers is numbers is [0 or 1 or 2, < 3, >= 4]: {numbers is [0 or 1 or 2, < 3, >= 4]}");

        if (numbers is [var first, .. var rest])
        {
            Console.WriteLine($"First number: {first}");
        }

        Console.WriteLine();
        Console.WriteLine("Pattern with switch expression: ");

        var emptyName = new string[0];
        var theName = new string[] { "Vu Truong" };
        var theNameBroken = new string[] { "Vu", "TruongP" };
        var theNameBroken2 = new string[] { "Vu", "Truong", "2022" };

        var funcs = (string[] pattern) =>
        {
            var name = pattern switch
            {
                [] => "Empty",
                [string fullName] => fullName,
                [string firstName, string lastName] => $"{firstName} {lastName}",
                _ => "Other case..."
            };

            return name;
        };

        Console.WriteLine($"Name []: {funcs(emptyName)}");
        Console.WriteLine($"Name [Vu Truong]: {funcs(theName)}");
        Console.WriteLine($"Name [Vu, Truong]: {funcs(theNameBroken)}");
        Console.WriteLine($"Name [Vu, Truong, 2022]: {funcs(theNameBroken2)}");
    }
}

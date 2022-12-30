namespace Dotnet7Benchmark;

public class MathUtilTest
{
    public static void Execute()
    {
        var round = 100;

        for(var i = 0; i < round; i++)
        {
            var numbers = Enumerable.Range(0, 100)
                .Select(x => Random.Shared.Next(0, 100))
                .ToArray();

            var sumLinq = numbers.Sum();
            var sumOpt = numbers.SumOpt();

            if (sumLinq != sumOpt)
                Console.WriteLine($"Fail. Round {i + 1} Expected: {sumLinq} - Actual: {sumOpt}");
        }

        Console.WriteLine("Sum test end");
    }
}

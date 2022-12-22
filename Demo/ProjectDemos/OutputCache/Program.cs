using Microsoft.AspNetCore.OutputCaching;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddOutputCache(opts =>
{
    opts.AddBasePolicy(b => b.NoCache());

    opts.AddPolicy("demo",
        b =>
        {
            b.Expire(TimeSpan.FromSeconds(3));
        });

    opts.AddPolicy("vary-id",
        b =>
        {
            b.Expire(TimeSpan.FromSeconds(10));
            b.SetVaryByQuery("id");
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseOutputCache();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.CacheOutput("demo")
.WithOpenApi();

app.MapGet("/by-id/{id}", [OutputCache(PolicyName = "vary-id")] (int id) =>
{
    return new WeatherForecast
    (
        DateOnly.FromDateTime(DateTime.Now.AddDays(id)),
        Random.Shared.Next(-20, 55),
        summaries[Random.Shared.Next(summaries.Length)]
    );
})
.WithName("GetWeatherForecastById")
.WithOpenApi();

app.MapGet("/by-name/{name}", (string name) =>
{
    return new WeatherForecast
    (
        DateOnly.FromDateTime(DateTime.Now.AddDays(10)),
        Random.Shared.Next(-20, 55),
        name
    );
})
.WithName("GetWeatherForecastByName")
.CacheOutput(p => p.SetVaryByQuery("namme").Expire(TimeSpan.FromSeconds(3)))
.WithOpenApi();

app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}

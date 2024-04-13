using Microsoft.Extensions.DependencyInjection;
using Cocona;
using System.Text.Json;

//CoconaApp.Run(([Argument(Description = "First Name")] string name, 
//               [Option(Description = "Last name")] string? lastName) =>
//{
//    Console.WriteLine($"Hello {name}");
//});

var builder = CoconaApp.CreateBuilder();

builder.Services.AddHttpClient();
builder.Services.AddSingleton<IWeatherService, OpenWeatherMapService>();

var app =  builder.Build();

app.AddCommand("weather", async (string city, IWeatherService weatherService) =>
{
    var weather = await weatherService.GetWeatherForCityAsync(city);
    Console.WriteLine(JsonSerializer.Serialize(weather, new JsonSerializerOptions{WriteIndented=true}));
});

app.Run();
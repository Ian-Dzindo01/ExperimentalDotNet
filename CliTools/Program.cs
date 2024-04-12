using Microsoft.Extensions.DependencyInjection;
using CliTools.Weather;
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

app.AddCommand("weather", async (IWeatherService weatherService) =>
{
    var weather = await weatherService.GetWeatherForCityAsync("Paris");
    Console.WriteLine(JsonSerializer.Serialize(weather, new JsonSerializerOptions{WriteIndented=true}));
});

app.Run();
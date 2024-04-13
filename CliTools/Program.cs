using Microsoft.Extensions.DependencyInjection;
using Cocona;
using Microsoft.Extensions.Logging;
using CliTools.Weather;

var builder = CoconaApp.CreateBuilder();

builder.Logging.AddFilter("System.Net.Http", LogLevel.Warning);

builder.Services.AddHttpClient();
builder.Services.AddSingleton<IWeatherService, OpenWeatherMapService>();

var app =  builder.Build();

app.AddCommands<WeatherCommands>();

app.Run();
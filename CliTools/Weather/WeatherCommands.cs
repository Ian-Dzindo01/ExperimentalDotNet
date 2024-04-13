using Cocona;
using System.Text.Json;

namespace CliTools.Weather
{
    public class WeatherCommands
    {
        private readonly IWeatherService _weatherService;

        public WeatherCommands(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        [Command("weather")]
        public async Task Weather(string city)
        {
            var weather = await _weatherService.GetWeatherForCityAsync(city);
            Console.WriteLine(JsonSerializer.Serialize(weather, new JsonSerializerOptions { WriteIndented = true }));
        }
    }
}

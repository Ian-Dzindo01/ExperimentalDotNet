using System.Net;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using CliTools.Models;

public interface IWeatherService
{
    Task<OpenWeatherMapService.WeatherResponse?> GetWeatherForCityAsync(string city);
}

public class OpenWeatherMapService : IWeatherService
{
    private const string ApiKey = "e2b7dcf3ba874ba8a5d141824241204";

    private readonly IHttpClientFactory _httpClientFactory;
        
    public OpenWeatherMapService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<WeatherResponse?> GetWeatherForCityAsync(string city)
    {
        var client = _httpClientFactory.CreateClient();
            
        var url = $"http://api.weatherapi.com/v1/current.json?key={ApiKey}&q={city}&aqi=no";

        var weatherResponse = await client.GetAsync(url);
        if (weatherResponse.StatusCode == HttpStatusCode.NotFound)
        {
            return null;
        }

        return await weatherResponse.Content.ReadFromJsonAsync<WeatherResponse>();
    }

    public class WeatherResponse
    {
        [JsonPropertyName("location")]
        public Location Location { get; set; }

        [JsonPropertyName("current")]
        public Current Current { get; set; }
    }
}

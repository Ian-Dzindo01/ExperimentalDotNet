using System.Net;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace CliTools.Weather;

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

        var url = $"http://api.weatherapi.com/v1/current.json?key={ApiKey}&q=Sarajevo&aqi=no";

        var weatherResponse = await client.GetAsync(url);
        if (weatherResponse.StatusCode == HttpStatusCode.NotFound)
        {
            return null;
        }

        return await weatherResponse.Content.ReadFromJsonAsync<WeatherResponse>();
    }

    public class WeatherResponse
    {
        [JsonPropertyName("main")] public OpenWeatherMapWeather Weather { get; set; }

        [JsonPropertyName("visibility")] public int Visibility { get; set; }

        [JsonPropertyName("dt")] public int Dt { get; set; }

        [JsonPropertyName("timezone")] public int Timezone { get; set; }

        [JsonPropertyName("id")] public int Id { get; set; }

        [JsonPropertyName("name")] public string Name { get; set; }

        [JsonPropertyName("cod")] public int Cod { get; set; }
    }

    public class OpenWeatherMapWeather
    {
        [JsonPropertyName("temp")] public double Temp { get; set; }

        [JsonPropertyName("feels_like")] public double FeelsLike { get; set; }

        [JsonPropertyName("temp_min")] public double TempMin { get; set; }

        [JsonPropertyName("temp_max")] public double TempMax { get; set; }

        [JsonPropertyName("pressure")] public int Pressure { get; set; }

        [JsonPropertyName("humidity")] public int Humidity { get; set; }
    }
}

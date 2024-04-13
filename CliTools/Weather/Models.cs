using System.Text.Json.Serialization;

namespace CliTools.Models
{
    public class Location
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("localtime")]
        public string LocalTime { get; set; }
    }

    public class Current
    {
        [JsonPropertyName("temp_c")]
        public double TemperatureCelsius { get; set; }

        [JsonPropertyName("wind_kph")]
        public double WindSpeedKph { get; set; }

        [JsonPropertyName("pressure_mb")]
        public double PressureMb { get; set; }

        [JsonPropertyName("humidity")]
        public int Humidity { get; set; }
    }
}

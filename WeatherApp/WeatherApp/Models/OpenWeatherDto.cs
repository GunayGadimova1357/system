using System.Text.Json.Serialization;

namespace WeatherApp.Models
{
    public sealed class OpenWeatherDto
    {
        [JsonPropertyName("name")] public string? Name { get; set; }
        [JsonPropertyName("main")] public MainDto Main { get; set; } = new();
        [JsonPropertyName("wind")] public WindDto Wind { get; set; } = new();
        [JsonPropertyName("weather")] public WeatherItemDto[] Weather { get; set; } = [];
    }

    public sealed class MainDto
    {
        [JsonPropertyName("temp")] public double Temp { get; set; }
        [JsonPropertyName("feels_like")] public double FeelsLike { get; set; }
        [JsonPropertyName("humidity")] public int Humidity { get; set; }
        [JsonPropertyName("pressure")] public int Pressure { get; set; }
    }

    public sealed class WindDto
    {
        [JsonPropertyName("speed")] public double Speed { get; set; }
    }

    public sealed class WeatherItemDto
    {
        [JsonPropertyName("description")] public string? Description { get; set; }
    }
}
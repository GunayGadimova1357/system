using System;

namespace WeatherApp.Models
{
    public sealed class WeatherInfo
    {
        public string City { get; init; } = "";
        public double TempC { get; init; }
        public string Description { get; init; } = "";
        public DateTime FetchedAt { get; init; }
    }
}
using System;
using System.Net.Http;
using System.Text.Json;
using WeatherApp.Models;
using System.Net;
using System.Threading.Tasks;

namespace WeatherApp.Services
{
    public sealed class WeatherService : IWeatherService
    {
        private readonly HttpClient _http;
        private readonly string _apiKey;

        public WeatherService(HttpClient http, string apiKey)
        {
            _http = http;
            _apiKey = apiKey;
        }

        public WeatherInfo GetCurrent(string city)
        {
            var url = $"https://api.openweathermap.org/data/2.5/weather?q={Uri.EscapeDataString(city)}&appid={_apiKey}&units=metric&lang=en";

            using var resp = _http.GetAsync(url).GetAwaiter().GetResult();

            if (!resp.IsSuccessStatusCode)
            {
                var body = resp.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                var msg = resp.StatusCode == HttpStatusCode.Unauthorized
                    ? "401 Unauthorized: check API."
                    : $"{(int)resp.StatusCode} {resp.StatusCode}: {body}";
                throw new HttpRequestException(msg);
            }

            var json = resp.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var dto  = JsonSerializer.Deserialize<OpenWeatherDto>(json)
                       ?? throw new InvalidOperationException("Empty weather response");

            return new WeatherInfo
            {
                City = dto.Name ?? city,
                TempC = dto.Main.Temp,
                Description = dto.Weather.Length > 0 ? dto.Weather[0].Description ?? "" : "",
                FetchedAt = DateTime.Now
            };
        }
    }
}
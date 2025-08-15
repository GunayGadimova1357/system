using WeatherApp.Models;

namespace WeatherApp.Services
{
    public interface IWeatherService
    {
        WeatherInfo GetCurrent(string city);
    }
}
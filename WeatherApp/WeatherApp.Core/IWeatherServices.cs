using WeatherApp.Core.Models;

namespace WeatherApp.WeatherApp.Core;

public interface IWeatherServices
{
    Task<WeatherForecast> GetWeatherForecastAsync(string cityName,CancellationToken ct = default);
}
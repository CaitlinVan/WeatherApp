namespace WeatherApp.Core;

public interface IWeatherService
{
    Task<WeatherForecast> GetWeatherForecastAsync(string cityName, CancellationToken ct = default);
}
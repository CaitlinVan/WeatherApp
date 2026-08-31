using System.Net.Http.Json;
using System.Text.Json.Serialization;
using WeatherApp.Core;

namespace WeatherApp.Infrastructure;

public class WeatherServices(HttpClient httpClient) : IWeatherService
{
    public async Task<WeatherForecast> GetWeatherForecastAsync(string cityName, CancellationToken ct = default)
    {
        
    }
}
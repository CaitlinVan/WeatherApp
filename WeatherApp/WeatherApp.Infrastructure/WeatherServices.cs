using System.Net.Http.Json;
using System.Text.Json.Serialization;
using WeatherApp.Core;

namespace WeatherApp.Infrastructure;

public class WeatherServices(HttpClient httpClient) : IWeatherService
{
    public async Task<WeatherForecast> GetWeatherForecastAsync(string cityName, CancellationToken ct = default)
    {
        var location = await FindCityAsync(cityName, ct);
        
        var url = $"https://api.open-meteo.com/v1/forecast" +
                  $"?latitude= {location.Latitude} &longitude= {location.Longitude}" +
                  $"&current=temperature_2m,wind_speed_10m,weather_code" +
                  $"&daily=temperature_2m_max,temperature_2m_min,weather_code" +
                  $"&timezone=auto";
        
        return new WeatherForecast(location);   
    }
}
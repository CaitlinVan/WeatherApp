using System.Net.Http.Json;
using WeatherApp.Core;
using WeatherApp.Core.Models;

namespace WeatherApp.Infrastructure;

public class WeatherServices(HttpClient httpClient) : IWeatherService
{
    public async Task<WeatherForecast> GetWeatherForecastAsync(string cityName, CancellationToken ct = default)
    {
        var location = await FindCityAsync(cityName, ct);

        var url = $"https://api.open-meteo.com/v1/forecast" +
                  $"?latitude={location.Latitude}&longitude={location.Longitude}" +
                  $"&current=temperature_2m,wind_speed_10m,weather_code" +
                  $"&daily=temperature_2m_max,temperature_2m_min,weather_code" +
                  $"&timezone=auto";

        var dto = await httpClient.GetFromJsonAsync<ForecastResponse>(url, ct)
                  ?? throw new InvalidOperationException("Failed to fetch forecast.");

        var current = new CurrentConditions
        {
            TemperatureCelsius = dto.Current.Temperature,
            WindSpeedKmh = dto.Current.WindSpeed,
            WeatherCode = dto.Current.WeatherCode,
            ObservedAt = dto.Current.Time
        };

        var dailyForecast = new List<ForecastDay>();

        for (int i = 0; i < dto.Daily.Time.Count; i++)
        {
            var day = new ForecastDay
            {
                Date = dto.Daily.Time[i],
                MaxTemperatureCelsius = dto.Daily.MaxTemp[i],
                MinTemperatureCelsius = dto.Daily.MinTemp[i],
                WeatherCode = dto.Daily.WeatherCode[i]
            };

            dailyForecast.Add(day);
        }

        return new WeatherForecast
        {
            Location = location,
            Current = current,
            DailyForecast = dailyForecast
        };
    }

    private async Task<Location> FindCityAsync(string cityName, CancellationToken ct)
    {
        var url = $"https://geocoding-api.open-meteo.com/v1/search?name={Uri.EscapeDataString(cityName)}&count=1";
        var response = await httpClient.GetFromJsonAsync<GeocodingResponse>(url, ct);

        var match = response?.Results?.FirstOrDefault()
                    ?? throw new InvalidOperationException($"City '{cityName}' not found.");

        return new Location
        {
            Name = match.Name,
            Latitude = match.Latitude,
            Longitude = match.Longitude
        };
    }
}
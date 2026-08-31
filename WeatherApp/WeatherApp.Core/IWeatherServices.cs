namespace WeatherApp.Core;

public interface IWeatherService
{
    Task<WeatherForecast> GetWeatherForecastAsync(string cityName, CancellationToken ct = default)
    {
        var location = await FindCityAsync(cityName, ct); 
        
        var url = $"http://api.open-meteo.com/v1/forecast" +
                  $"?latitude ={{location.Latitude}}&longitude={{location.Longitude}}" +
                  $"&current=temperature_2m,wind_speed_10m,weather_code" +
                  $"&daily=temperature_2m_max,temperature_2m_min,weather_code" +
                  $"&timezone=auto";
                  
    }
}
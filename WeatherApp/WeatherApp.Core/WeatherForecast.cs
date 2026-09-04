namespace WeatherApp.Core.Models;

public class WeatherForecast
{
    public Location Location { get; set; } = new();
    public CurrentCondition Current { get; set; } = new();
    public List<ForecastDay> DailyForecast { get; set; } = new();
}
namespace WeatherApp.Core.Models;

public class ForecastDay
{
    public DateOnly Date { get; set; }
    public double MaxTemperatureCelsius { get; set; }
    public double MinTemperatureCelsius { get; set; }
    public int WeatherCode { get; set; }
}
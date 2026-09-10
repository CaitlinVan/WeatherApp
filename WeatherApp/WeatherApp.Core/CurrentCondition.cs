namespace WeatherApp.WeatherApp.Core;

public class CurrentCondition
{
    public double TemperatureCelsius { get; set; }
    public double WindSpeedKmh { get; set; }
    public int WeatherCode { get; set; }
    public DateTime ObservedAt { get; set; }
}
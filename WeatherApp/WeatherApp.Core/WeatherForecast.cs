namespace WeatherApp.WeatherApp.Core;

public class WeatherForecast
{
    public Location location { get; set; }
    public IReadOnlyList<ForecastDay> forecast { get; set; }
    public CurrentCondition currentCondition { get; set; }
}
namespace WeatherApp.WeatherApp.Core;

public class ForecastDay
{
    public DateTime date { get; set; }
    public double maxTemperature { get; set; }
    public double minTemperature { get; set; }
    public int weatherCode { get; set; }
}
namespace WeatherApp.Core.Models;

public class CurrentCondition
{
   public double TemperatureCelsius { get; set; }
   public double WindSpeedKph { get; set; }
   public int WeatherCode { get; set; }
   public DateTime ObservedAt { get; set; }
}
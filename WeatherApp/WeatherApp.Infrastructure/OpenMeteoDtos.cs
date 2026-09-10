using System.Text.Json.Serialization;

namespace WeatherApp.WeatherApp.Infrastructure;

//Dtos primary responsibility is to transfer data throughout the different layers in the app. 

public class GeocodingResponse()
{
    public List<GeocodingResult>?  Results { get; set; }
}

public class GeocodingResult()
{
    public string Name { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}

public class CurrentDTO()
{
    [JsonPropertyName("time")]
    public DateTime Time { get; set; }
    
    [JsonPropertyName("temperature_2m")]
    public double Temperature { get; set; }
    
    [JsonPropertyName("wind_speed_10m")]
    public double WindSpeed { get; set; }
    
    [JsonPropertyName("weather_code")]
    public int WeatherCode { get; set; }
    
}

public class DailyDTO()
{
    [JsonPropertyName("time")]
    public List<DateOnly> Time { get; set; }
    
    [JsonPropertyName("temperature_2m_max")]
    public List<double> TemperatureMax { get; set; }
    
    [JsonPropertyName("temperature_2m_min")]
    public List<double> TemperatureMin { get; set; }
    
    [JsonPropertyName("weather_code")]
    public int WeatherCode { get; set; }
    
}

public class ForecastResponse()
{
    public CurrentDTO? Current { get; set; }
    public DailyDTO? Daily { get; set; }
}



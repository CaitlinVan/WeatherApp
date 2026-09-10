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
    public DateTime time { get; set; }
    
    [JsonPropertyName("temperature_2m")]
    public double Temperature { get; set; }
    
    
}

public class DailyDTO()
{
    
}

public class ForecastResponse()
{}



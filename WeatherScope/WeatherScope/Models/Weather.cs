using System.Text.Json.Serialization;

namespace WeatherScope.Models
{
    public class Weather
    {
        [JsonPropertyName("coord")]
        public Coord Coordinates { get; set; }

        [JsonPropertyName("weather")]
        public WeatherDetails[] WeatherDetails { get; set; }

        [JsonPropertyName("main")]
        public Main Main { get; set; }

        [JsonPropertyName("wind")]
        public Wind Wind { get; set; }

        [JsonPropertyName("name")]
        public string CityName { get; set; }
    }

    public class Coord
    {
        [JsonPropertyName("lon")]
        public double Longitude { get; set; }

        [JsonPropertyName("lat")]
        public double Latitude { get; set; }
    }

    public class WeatherDetails
    {
        [JsonPropertyName("description")]
        public string Description { get; set; }
    }

    public class Main
    {
        [JsonPropertyName("temp")]
        public double Temperature { get; set; }

        [JsonPropertyName("feels_like")]
        public double FeelsLike { get; set; }

        [JsonPropertyName("temp_min")]
        public double TempMin { get; set; }

        [JsonPropertyName("temp_max")]
        public double TempMax { get; set; }

        [JsonPropertyName("pressure")]
        public int Pressure { get; set; }

        [JsonPropertyName("humidity")]
        public int Humidity { get; set; }
    }

    public class Wind
    {
        [JsonPropertyName("speed")]
        public double Speed { get; set; }

        [JsonPropertyName("deg")]
        public int Direction { get; set; }
    }
}

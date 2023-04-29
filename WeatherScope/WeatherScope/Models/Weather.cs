namespace WeatherScope.Models
{
    public class Weather
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string CityName { get; set; }
        public string Description { get; set; }
        public double Temperature { get; set; }
        public double FeelsLike { get; set; }
        public double TempMin { get; set; }
        public double TempMax { get; set; }
        public int Pressure { get; set; }
        public int Humidity { get; set; }
        public double WindSpeed { get; set; }
        public int WindDirection { get; set; }
    }

}

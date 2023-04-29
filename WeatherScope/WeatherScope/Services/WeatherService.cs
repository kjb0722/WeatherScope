using System.Text.Json;
using WeatherScope.Models;

namespace WeatherScope.Services
{
    public class WeatherService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey = "api key";
        private readonly string _baseUrl = "http://api.openweathermap.org/data/2.5/weather";

        public WeatherService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Weather> GetWeatherAsync(double latitude, double longitude)
        {
            var url = $"{_baseUrl}?lat={latitude}&lon={longitude}&appid={_apiKey}&units=metric";
            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var weather = JsonSerializer.Deserialize<Weather>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                return weather;
            }
            else
            {
                throw new HttpRequestException("Failed to get weather data from API");
            }
        }
    }
}

using Newtonsoft.Json;
using WeatherScope.Models;

namespace WeatherScope.Services
{
    public class WeatherService
    {
        private readonly HttpClient _httpClient;
        private static readonly string ApiKey = Environment.GetEnvironmentVariable("OpenWeatherMapApiKey");
        private const string BaseUrl = "https://api.openweathermap.org/data/2.5/weather";

        public WeatherService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<WeatherResponse> GetWeatherAsync(double latitude, double longitude)
        {
            string url = $"{BaseUrl}?lat={latitude}&lon={longitude}&appid={ApiKey}&units=metric";
            //https://api.openweathermap.org/data/2.5/weather?lat={lat}&lon={lon}&appid={API key}
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<WeatherResponse>(json);
        }
    }
}

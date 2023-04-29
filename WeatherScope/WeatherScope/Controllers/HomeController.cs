using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WeatherScope.Models;
using WeatherScope.Services;

namespace WeatherScope.Controllers
{
    public class HomeController : Controller
    {
        private readonly WeatherService _weatherService;

        public HomeController(WeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        public async Task<IActionResult> Index()
        {
            // 예시 위치 (위도, 경도)
            double latitude = 37.7749;
            double longitude = -122.4194;

            Weather weather = await _weatherService.GetWeatherAsync(latitude, longitude);
            return View(weather);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
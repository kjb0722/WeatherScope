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

        public async Task<IActionResult> Index(double? latitude, double? longitude)
        {
            if (latitude.HasValue && longitude.HasValue)
            {
                var weather = await _weatherService.GetWeatherAsync(latitude.Value, longitude.Value);
                return View(weather);
            }

            return View();
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
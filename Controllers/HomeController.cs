using Microsoft.AspNetCore.Mvc;
using WeatherScope.Services;

public class HomeController : Controller
{
    private readonly WeatherService _weatherService;

    public HomeController(WeatherService weatherService)
    {
        _weatherService = weatherService;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(double? latitude, double? longitude)
    {
        if (latitude.HasValue && longitude.HasValue)
        {
            var weather = await _weatherService.GetWeatherAsync(latitude.Value, longitude.Value);
            return View(weather);
        }

        return View();
    }
}

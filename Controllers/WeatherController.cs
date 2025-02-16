using Microsoft.AspNetCore.Mvc;
using WeatherApp.Services;

namespace WeatherApp.Controllers
{
    public class WeatherController : Controller
    {
        //Service for weather
        private readonly WeatherServices _weatherServices;

        public WeatherController(WeatherServices weatherServices)
        {
            _weatherServices = weatherServices; //Injecting the service
        }

        //Action for getting the weather
        public async Task<IActionResult> GetWeather(double lat, double lon)
        {
            var weatherData = await _weatherServices.GetWeatherAsync(lat, lon);
            ViewBag.Clima = weatherData;
            return View();
        }

        //Action for getting the forecast

        public async Task<IActionResult> GetForecast(double lat, double lon)
        {
            var forecastData = await _weatherServices.GetForecastAsync(lat, lon);
            ViewBag.Clima = forecastData;
            return View();
        }

        //Action for the search view
        public IActionResult WeatherSearch()
        {
            return View();
        }

    }
}

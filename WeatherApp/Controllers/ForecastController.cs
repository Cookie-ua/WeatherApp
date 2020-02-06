using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeatherApp.Interfaces;

namespace WeatherApp.Controllers
{
    public class ForecastController : Controller
    {
        private readonly IForecastRepository _forecastRepository;

        public ForecastController(IForecastRepository forecastRepository)
        {
            _forecastRepository = forecastRepository;
        }

        public IActionResult Search(string city)
        {
            if (!String.IsNullOrEmpty(city))
            {
                var cities = _forecastRepository.GetCities(city);
                ViewBag.City = city;

                return View(cities);
            }

            return View();
        }

        public IActionResult City(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Search", "Forecast");
            }
            var forecastViewModel = _forecastRepository.GetForecast((int)id);

            return View(forecastViewModel);
        }
    }
}
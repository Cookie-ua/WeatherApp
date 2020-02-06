using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.Models.OpenWeatherModels.Forecast;
using WeatherApp.ViewModels;

namespace WeatherApp.Interfaces
{
    public interface IForecastRepository
    {
        ForecastViewModel GetForecast(int cityId);
        IEnumerable<CityForecastViewModel> GetCities(string city);
    }
}

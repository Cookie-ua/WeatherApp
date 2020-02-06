using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApp.Models.OpenWeatherModels.Forecast
{
    public class ResponseCityForecast
    {
        public string Message { get; set; }
        public int Cod { get; set; }
        public int Count { get; set; }
        public List<CityForecast> List { get; set; }
    }

    public class CityForecast
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Coord Coord { get; set; }
        public Main Main { get; set; }
        public int Dt { get; set; }
        public Wind Wind { get; set; }
        public Sys Sys { get; set; }
        public Clouds Clouds { get; set; }
        public List<Weather> Weather { get; set; }
    }
}

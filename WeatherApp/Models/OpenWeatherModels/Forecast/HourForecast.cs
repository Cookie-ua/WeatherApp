using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApp.Models.OpenWeatherModels.Forecast
{
    public class ResponseHourForecast
    {
        public string Message { get; set; }
        public int Cod { get; set; }
        public int Cnt { get; set; }
        public List<HourForecast> List { get; set; }
    }

    public class HourForecast
    {
        public Main Main { get; set; }
        public int Dt { get; set; }
        public Wind Wind { get; set; }
        public Clouds Clouds { get; set; }
        public List<Weather> Weather { get; set; }
    }
}

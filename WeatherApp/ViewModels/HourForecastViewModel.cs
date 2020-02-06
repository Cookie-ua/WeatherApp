using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApp.ViewModels
{
    public class HourForecastViewModel
    {
        public float Temp { get; set; }
        public string WeatherDescription { get; set; }
        public DateTimeOffset Date { get; set; }
        public float WindSpeed { get; set; }
        public int Clouds { get; set; }
        public string Icon { get; set; }
    }
}

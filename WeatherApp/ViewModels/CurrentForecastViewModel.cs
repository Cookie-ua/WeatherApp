using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApp.ViewModels
{
    public class CurrentForecastViewModel
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public float Temp { get; set; }
        public string WeatherDescription { get; set; }
        public DateTimeOffset Date { get; set; }
        public float WindSpeed { get; set; }
        public double Pressure { get; set; }
        public int Humidity { get; set; }
        public int Visibility { get; set; }
        public string Icon { get; set; }
    }
}

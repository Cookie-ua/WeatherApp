using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApp.ViewModels
{
    public class CityForecastViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public float Temp { get; set; }
        public float TempMin { get; set; }
        public float TempMax { get; set; }
        public string WeatherDescription { get; set; }
        public int Clouds { get; set; }
        public float WindSpeed { get; set; }
        public string Icon { get; set; }
    }
}
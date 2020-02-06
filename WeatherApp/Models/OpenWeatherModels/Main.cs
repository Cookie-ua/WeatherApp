using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApp.Models.OpenWeatherModels
{
    public class Main
    {
        public float Temp { get; set; }
        public double Pressure { get; set; }
        public int Humidity { get; set; }
        public float Temp_Min { get; set; }
        public float Temp_Max { get; set; }
    }
}

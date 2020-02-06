using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApp.ViewModels
{
    public class ForecastViewModel
    {
        public CurrentForecastViewModel CurrentForecast { get; set; }
        public IEnumerable<HourForecastViewModel> HourForecast { get; set; }
    }
}

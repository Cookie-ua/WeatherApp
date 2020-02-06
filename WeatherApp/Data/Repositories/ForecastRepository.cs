using AutoMapper;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.Interfaces;
using WeatherApp.Models.OpenWeatherModels.Forecast;
using WeatherApp.ViewModels;

namespace WeatherApp.Data.Repositories
{
    public class ForecastRepository : IForecastRepository
    {
        private readonly IMapper _mapper;
        public IConfiguration Configuration { get; }
        public ForecastRepository(IConfiguration configuration, IMapper mapper)
        {
            Configuration = configuration;
            _mapper = mapper;
        }

        public IEnumerable<CityForecastViewModel> GetCities(string city)
        {
            var APP_ID = Configuration["OpenWeatherMap:APPID"];
            var client = new RestClient($"https://api.openweathermap.org/data/2.5/find?q={city}&appid={APP_ID}&units=metric");
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            if (response.IsSuccessful)
            {
                var content = JsonConvert.DeserializeObject<JToken>(response.Content);
                var res = content.ToObject<ResponseCityForecast>();
                return _mapper.Map<IEnumerable<CityForecast>, IEnumerable<CityForecastViewModel>>(res.List);
            }

            return null;
        }

        public ForecastViewModel GetForecast(int cityId)
        {
            return new ForecastViewModel()
            {
                CurrentForecast = GetCurrentForecast(cityId),
                HourForecast = GetHourForecast(cityId)
            };
        }

        private CurrentForecastViewModel GetCurrentForecast(int cityId)
        {
            var APP_ID = Configuration["OpenWeatherMap:APPID"];
            var client = new RestClient($"https://api.openweathermap.org/data/2.5/weather?id={cityId}&appid={APP_ID}&units=metric");
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            if (response.IsSuccessful)
            {
                var content = JsonConvert.DeserializeObject<JToken>(response.Content);
                var res = content.ToObject<CurrentForecast>();
                return _mapper.Map<CurrentForecast, CurrentForecastViewModel>(res);
            }

            return null;
        }

        private IEnumerable<HourForecastViewModel> GetHourForecast(int cityId)
        {
            var APP_ID = Configuration["OpenWeatherMap:APPID"];
            var client = new RestClient($"https://api.openweathermap.org/data/2.5/forecast?id={cityId}&appid={APP_ID}&units=metric");
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            if (response.IsSuccessful)
            {
                var content = JsonConvert.DeserializeObject<JToken>(response.Content);
                var res = content.ToObject<ResponseHourForecast>();
                
                return _mapper.Map<IEnumerable<HourForecast>, IEnumerable<HourForecastViewModel>>(res.List.Take(8));
            }

            return null;
        }
    }
}

using AutoMapper;
using System;
using System.Globalization;
using WeatherApp.Models.OpenWeatherModels.Forecast;
using WeatherApp.ViewModels;

namespace WeatherApp.Data.Mapping
{
    public class ForecastMappingProfile : Profile
    {
        public ForecastMappingProfile()
        {
            CreateMap<CityForecast, CityForecastViewModel>()
                .ForMember(o => o.Country, x => x.MapFrom(src => src.Sys.Country))
                .ForMember(o => o.Temp, x => x.MapFrom(src => Math.Round(src.Main.Temp, 1)))
                .ForMember(o => o.TempMin, x => x.MapFrom(src => Math.Round(src.Main.Temp_Min, 1)))
                .ForMember(o => o.TempMax, x => x.MapFrom(src => Math.Round(src.Main.Temp_Max, 1)))
                .ForMember(o => o.WindSpeed, x => x.MapFrom(src => src.Wind.Speed))
                .ForMember(o => o.Clouds, x => x.MapFrom(src => src.Clouds.All))
                .ForMember(o => o.WeatherDescription, x => x.MapFrom(src => CultureInfo.CurrentCulture.TextInfo.ToTitleCase(src.Weather[0].Description)))
                .ForMember(o => o.Icon, x => x.MapFrom(src => src.Weather[0].Icon));

            CreateMap<HourForecast, HourForecastViewModel>()
                .ForMember(i => i.Date, opt => opt.ConvertUsing(new DateValueFormatter(), src => src.Dt))
                .ForMember(o => o.Temp, x => x.MapFrom(src => Math.Round(src.Main.Temp, 1)))
                .ForMember(o => o.WindSpeed, x => x.MapFrom(src => src.Wind.Speed))
                .ForMember(o => o.Clouds, x => x.MapFrom(src => src.Clouds.All))
                .ForMember(o => o.WeatherDescription, x => x.MapFrom(src => CultureInfo.CurrentCulture.TextInfo.ToTitleCase(src.Weather[0].Description)))
                .ForMember(o => o.Icon, x => x.MapFrom(src => src.Weather[0].Icon));

            CreateMap<CurrentForecast, CurrentForecastViewModel>()
                .ForMember(i => i.Date, opt => opt.ConvertUsing(new DateValueFormatter(), src => src.Dt))
                .ForMember(o => o.Temp, x => x.MapFrom(src => Math.Round(src.Main.Temp, 1)))
                .ForMember(o => o.WindSpeed, x => x.MapFrom(src => src.Wind.Speed))
                .ForMember(o => o.Icon, x => x.MapFrom(src => src.Weather[0].Icon))
                .ForMember(o => o.Country, x => x.MapFrom(src => src.Sys.Country))
                .ForMember(o => o.WeatherDescription, x => x.MapFrom(src => CultureInfo.CurrentCulture.TextInfo.ToTitleCase(src.Weather[0].Description)))
                .ForMember(o => o.Humidity, x => x.MapFrom(src => src.Main.Humidity))
                .ForMember(o => o.Pressure, x => x.MapFrom(src => Math.Round(src.Main.Pressure * 0.750062, 2)));
        }
    }

    public class DateValueFormatter : IValueConverter<int, DateTimeOffset>
    {
        public DateTimeOffset Convert(int sourceMember, ResolutionContext context)
        {
            return new DateTimeOffset(1970, 1, 1, 0, 0, 0, new TimeSpan(0, 0, 0)).AddSeconds(sourceMember).ToLocalTime();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorldWeb.Models
{
    public class DailyWeatherRecord
    {
        public const float KELVIN_CONST = 273.15f;
        public float Temperature { get; set; }

        public WeatherType Type { get; set; }

        public DateTime Day { get; set; }


        public DailyWeatherRecord(DateTime day, float temperature, WeatherType type)
        {
            this.Day = day;
            this.Temperature = temperature;
            this.Type = type;
        }


        public static float KelvinToCelsius(float temp)
        {
            return temp - KELVIN_CONST;
        }
    }

}

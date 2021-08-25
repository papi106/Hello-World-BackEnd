using HelloWorldWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// <see href="https://openweathermap.org/api">API weather</see>
/// </summary>


namespace HelloWorldWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly string latitude = "46.7700";
        private readonly string longitude = "23.5800";
        private readonly string apiKey = "8446f067eeb54c9d8d875421211208";

        // Create a constructor (I = interface)
        public WeatherController(IWeatherControllerSettings conf)
        {

            longitude = conf.Longitude;
            latitude = conf.Latitude;
            apiKey = conf.ApiKey;
        }

        // GET: api/<WeatherController>
        [HttpGet]
        public IEnumerable<DailyWeatherRecord> Get()
        {
            //var client = new RestClient($"https://api.openweathermap.org/data/2.5/onecall?lat=46.7700&lon=23.5800&exclude=hourly,minutely&appid=87c518ece5346b1e8f0e944352222508");

            var client = new RestClient($"https://api.openweathermap.org/data/2.5/onecall?lat={latitude}&lon={longitude}&exclude=hourly,minutely&appid={apiKey}")
            {
                Timeout = -1            //no timeout at all
            };
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            return ConvertResponseToWeatherRecordList(response.Content);            
            
        }

        [NonAction]
        public IEnumerable<DailyWeatherRecord> ConvertResponseToWeatherRecordList(string content)
        {
            var json = JObject.Parse(content);   
            
            var jsonArray = json["daily"].Take(7);

            return jsonArray.Select(CreateDailyWeatherRecordFromJToken);
                        
        }

        private DailyWeatherRecord CreateDailyWeatherRecordFromJToken(JToken item)
        {
            long unixDateTime = item.Value<long>("dt");
            var temperature = item.SelectToken("temp");
            string weather = item.SelectToken("weather")[0].Value<string>("description");

            DateTime formatDateTime = DateTimeOffset.FromUnixTimeSeconds(unixDateTime).DateTime.Date;
            float formatTemperature = DailyWeatherRecord.KelvinToCelsius(temperature.Value<float>("day"));
            WeatherType formatType = Convert(weather);

            DailyWeatherRecord dailyWeatherRecord = new(formatDateTime, formatTemperature, formatType);
            return dailyWeatherRecord;
        }

        //Converting weather type
        private static WeatherType Convert(string weather)
        {
            return weather switch
            {
                "few clouds" => WeatherType.FewClouds,
                "light rain" => WeatherType.LightRain,
                "broken clouds" => WeatherType.BrokenClouds,
                "scattered clouds" => WeatherType.ScatteredClouds,
                "clear sky" => WeatherType.ClearSky,
                "moderate rain" => WeatherType.ModerateRain,
                "overcast clouds" => WeatherType.OvercastClouds,
                _ => throw new Exception($"Unknown weather type {weather}!"),
            };
        }

        /// <summary>
        /// Get a weather forecast for the day in specified amount of days from now.
        /// </summary>
        /// <param name="index">Amount of days from now.</param>
        /// <returns>The weather forecast.</returns>
        [HttpGet("{index}")]
        public string Get(int index)
        {
            return "value";    
        }

    }
}

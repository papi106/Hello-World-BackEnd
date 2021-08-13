using HelloWorldWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


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

            var client = new RestClient($"https://api.openweathermap.org/data/2.5/onecall?lat={latitude}&lon={longitude}&exclude=hourly,minutely&appid={apiKey}");
            client.Timeout = -1;            //no timeout at all
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            return ConvertResponseToWeatherRecordList(response.Content);            
            
        }

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
            WeatherType formatType = this.Convert(weather);

            DailyWeatherRecord dailyWeatherRecord = new DailyWeatherRecord(formatDateTime, formatTemperature, formatType);
            return dailyWeatherRecord;
        }

        //Converting weather type
        private WeatherType Convert(string weather)
        {
            switch (weather)
            {
                case "few clouds":
                    return WeatherType.FewClouds;
                case "light rain":
                    return WeatherType.LightRain;
                case "broken clouds":
                    return WeatherType.BrokenClouds;
                case "scattered clouds":
                    return WeatherType.ScatteredClouds;
                case "clear sky":
                    return WeatherType.ClearSky;
                default:
                    throw new Exception($"Unknown weather type {weather}!");
            }
        }


        // GET api/<WeatherController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<WeatherController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<WeatherController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<WeatherController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

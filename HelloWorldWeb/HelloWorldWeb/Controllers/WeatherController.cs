﻿using HelloWorldWeb.Models;
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
        private readonly string apiKey = "8446f067eeb54c9d8d875421211208"; //my API key

        // GET: api/<WeatherController>
        [HttpGet]
        public IEnumerable<DailyWeatherRecord> Get()
        {
            //lat 46.7700 lon 23.5800
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

            List<DailyWeatherRecord> result = new List<DailyWeatherRecord>();
            var jsonArray = json["daily"];
            foreach (var item in jsonArray)
            {
                //TODO: Convert item to DailyWeatherRecord

                //DailyWeatherRecord - CLASS - ALWAYS PascalCase
                DailyWeatherRecord dailyWeatherRecord = new DailyWeatherRecord(new DateTime(2021, 8, 12), 22.0f, WeatherType.Mild);

                //dailyWeatherRecord - OBJECT - ALWAYS camelCase
                result.Add(dailyWeatherRecord); 

                //CLASS can have many OBJECTS, so one OBJECT is in within a CLASS 
            }
            return result;

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

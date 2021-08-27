// <copyright file="Startup.cs" company="Principal33 Solutions SRL">
// Copyright (c) Principal33 Solutions SRL. All rights reserved.
// </copyright>

using HelloWorldWeb.Controllers;
using Microsoft.Extensions.Configuration;

namespace HelloWorldWeb
{
    public class WeatherControllerSettings : IWeatherControllerSettings
    {
        public WeatherControllerSettings(IConfiguration conf)
        {
            ApiKey = conf["WeatherForecast:ApiKey"];
            Longitude = conf["WeatherForecast:Longitude"];
            Latitude = conf["WeatherForecast:Latitude"];
        }
        public string Longitude { get; set; }

        public string Latitude { get; set; }

        public string ApiKey { get; set; }
    }
}
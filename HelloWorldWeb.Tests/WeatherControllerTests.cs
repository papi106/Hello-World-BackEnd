using HelloWorldWeb.Controllers;
using HelloWorldWeb.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HelloWorldWeb.Tests
{
    public class WeatherControllerTests
    {

        [Fact]
        public void TestCheckingConversion()
        {
            //Assume
            //string content = "{ \"lat\":46.77,\"lon\":23.58,\"timezone\":\"Europe/Bucharest\",\"timezone_offset\":10800,\"current\":{ \"dt\":1628796281,\"sunrise\":1628738379,\"sunset\":1628790117,\"temp\":289.93,\"feels_like\":289.54,\"pressure\":1023,\"humidity\":72,\"dew_point\":284.86,\"uvi\":0,\"clouds\":0,\"visibility\":10000,\"wind_speed\":1.54,\"wind_deg\":250,\"weather\":[{ \"id\":500,\"main\":\"Rain\",\"description\":\"light rain\",\"icon\":\"10n\"}],\"rain\":{ \"1h\":0.21} },\"daily\":[{ \"dt\":1628762400,\"sunrise\":1628738379,\"sunset\":1628790117,\"moonrise\":1628753220,\"moonset\":1628797740,\"moon_phase\":0.13,\"temp\":{ \"day\":299.62,\"min\":289.93,\"max\":300.23,\"night\":289.94,\"eve\":294.62,\"morn\":290.2},\"feels_like\":{ \"day\":299.62,\"night\":289.45,\"eve\":294.18,\"morn\":289.79},\"pressure\":1020,\"humidity\":38,\"dew_point\":283.6,\"wind_speed\":5.29,\"wind_deg\":323,\"wind_gust\":6.43,\"weather\":[{ \"id\":500,\"main\":\"Rain\",\"description\":\"light rain\",\"icon\":\"10d\"}],\"clouds\":14,\"pop\":0.2,\"rain\":0.21,\"uvi\":6.81},{ \"dt\":1628848800,\"sunrise\":1628824856,\"sunset\":1628876420,\"moonrise\":1628844180,\"moonset\":1628885400,\"moon_phase\":0.17,\"temp\":{ \"day\":299.85,\"min\":287.28,\"max\":302,\"night\":292.3,\"eve\":300.39,\"morn\":287.79},\"feels_like\":{ \"day\":299.54,\"night\":291.58,\"eve\":300.04,\"morn\":286.88},\"pressure\":1023,\"humidity\":34,\"dew_point\":282.16,\"wind_speed\":3.42,\"wind_deg\":336,\"wind_gust\":4.13,\"weather\":[{ \"id\":802,\"main\":\"Clouds\",\"description\":\"scattered clouds\",\"icon\":\"03d\"}],\"clouds\":39,\"pop\":0,\"uvi\":6.93},{ \"dt\":1628935200,\"sunrise\":1628911334,\"sunset\":1628962722,\"moonrise\":1628935140,\"moonset\":1628973240,\"moon_phase\":0.2,\"temp\":{ \"day\":302.5,\"min\":289.3,\"max\":304.54,\"night\":294.89,\"eve\":303.31,\"morn\":289.71},\"feels_like\":{ \"day\":301.45,\"night\":294.29,\"eve\":302.48,\"morn\":288.94},\"pressure\":1021,\"humidity\":32,\"dew_point\":283.63,\"wind_speed\":2.84,\"wind_deg\":342,\"wind_gust\":4.01,\"weather\":[{ \"id\":803,\"main\":\"Clouds\",\"description\":\"broken clouds\",\"icon\":\"04d\"}],\"clouds\":57,\"pop\":0,\"uvi\":6.91},{ \"dt\":1629021600,\"sunrise\":1628997812,\"sunset\":1629049023,\"moonrise\":1629026280,\"moonset\":0,\"moon_phase\":0.25,\"temp\":{ \"day\":305.23,\"min\":291.93,\"max\":307.09,\"night\":298.74,\"eve\":307.09,\"morn\":292.14},\"feels_like\":{ \"day\":304.06,\"night\":298.45,\"eve\":305.74,\"morn\":291.48},\"pressure\":1016,\"humidity\":30,\"dew_point\":284.84,\"wind_speed\":4.02,\"wind_deg\":346,\"wind_gust\":6.5,\"weather\":[{ \"id\":800,\"main\":\"Clear\",\"description\":\"clear sky\",\"icon\":\"01d\"}],\"clouds\":0,\"pop\":0.01,\"uvi\":7.08},{ \"dt\":1629108000,\"sunrise\":1629084289,\"sunset\":1629135322,\"moonrise\":1629117480,\"moonset\":1629061260,\"moon_phase\":0.28,\"temp\":{ \"day\":301.98,\"min\":292.51,\"max\":307.82,\"night\":295.94,\"eve\":306.22,\"morn\":292.51},\"feels_like\":{ \"day\":301.42,\"night\":295.89,\"eve\":304.96,\"morn\":292.25},\"pressure\":1015,\"humidity\":38,\"dew_point\":285.7,\"wind_speed\":3.03,\"wind_deg\":139,\"wind_gust\":3.93,\"weather\":[{ \"id\":500,\"main\":\"Rain\",\"description\":\"light rain\",\"icon\":\"10d\"}],\"clouds\":69,\"pop\":0.59,\"rain\":1.02,\"uvi\":7.1},{ \"dt\":1629194400,\"sunrise\":1629170767,\"sunset\":1629221620,\"moonrise\":1629208500,\"moonset\":1629149760,\"moon_phase\":0.31,\"temp\":{ \"day\":304.34,\"min\":293.21,\"max\":305.87,\"night\":295.43,\"eve\":305.87,\"morn\":293.21},\"feels_like\":{ \"day\":303.51,\"night\":295.52,\"eve\":304.95,\"morn\":292.99},\"pressure\":1012,\"humidity\":34,\"dew_point\":286.05,\"wind_speed\":4.18,\"wind_deg\":329,\"wind_gust\":4.37,\"weather\":[{ \"id\":500,\"main\":\"Rain\",\"description\":\"light rain\",\"icon\":\"10d\"}],\"clouds\":9,\"pop\":0.39,\"rain\":1.01,\"uvi\":6.23},{ \"dt\":1629280800,\"sunrise\":1629257245,\"sunset\":1629307917,\"moonrise\":1629299100,\"moonset\":1629238800,\"moon_phase\":0.35,\"temp\":{ \"day\":295.95,\"min\":291.57,\"max\":301.12,\"night\":292.4,\"eve\":301.12,\"morn\":292.28},\"feels_like\":{ \"day\":296.11,\"night\":292.44,\"eve\":301.48,\"morn\":292.42},\"pressure\":1010,\"humidity\":70,\"dew_point\":289.35,\"wind_speed\":4.68,\"wind_deg\":320,\"wind_gust\":9.11,\"weather\":[{ \"id\":500,\"main\":\"Rain\",\"description\":\"light rain\",\"icon\":\"10d\"}],\"clouds\":91,\"pop\":0.6,\"rain\":3.72,\"uvi\":7},{ \"dt\":1629367200,\"sunrise\":1629343723,\"sunset\":1629394213,\"moonrise\":1629389040,\"moonset\":1629328560,\"moon_phase\":0.39,\"temp\":{ \"day\":295.68,\"min\":288.72,\"max\":297.24,\"night\":291.77,\"eve\":297.24,\"morn\":288.72},\"feels_like\":{ \"day\":295.56,\"night\":291.52,\"eve\":297.04,\"morn\":288.79},\"pressure\":1010,\"humidity\":60,\"dew_point\":286.94,\"wind_speed\":4.24,\"wind_deg\":292,\"wind_gust\":9.47,\"weather\":[{ \"id\":501,\"main\":\"Rain\",\"description\":\"moderate rain\",\"icon\":\"10d\"}],\"clouds\":97,\"pop\":1,\"rain\":6.68,\"uvi\":7}]}";
            var weatherControllerSettingsMock = new Mock<IWeatherControllerSettings>();
            string content = LoadJsonFromResource();

            WeatherController weatherController = new(weatherControllerSettingsMock.Object);


            //Act
            var result = weatherController.ConvertResponseToWeatherRecordList(content);

            //Assert
            Assert.Equal(7, result.Count());
            var firstDay = result.First();

            Assert.Equal(new DateTime(2021, 08, 13), firstDay.Day);
            Assert.Equal(DailyWeatherRecord.KelvinToCelsius(299.07f), firstDay.Temperature);
            Assert.Equal(WeatherType.FewClouds, firstDay.Type);
        }

        private string LoadJsonFromResource()
        {
            var resourceName = "HelloWorldWeb.Tests.TestData.ContentWeatherApi.json";
            var assembly = this.GetType().Assembly;
            var resourceStream = assembly.GetManifestResourceStream(resourceName);

            using var tr = new StreamReader(resourceStream);
            return tr.ReadToEnd();
        }
    }
}

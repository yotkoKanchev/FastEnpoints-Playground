using FastEnpointsDemo.Contracts.Requests;
using FastEnpointsDemo.Contracts.Responses;
using FastEndpoints;
using FastEnpointsDemo.Models;

namespace FastEnpointsDemo.Mappers
{
    public class WeatherForecastMapper : Mapper<WeatherForecastRequest, WeatherForecastResponse, WeatherForecast>
    {
        public override WeatherForecastResponse FromEntity(WeatherForecast e)
        {
            return new WeatherForecastResponse()
            {
                Date = e.Date,
                Summary = e.Summary,
                TemperatureC = e.TemperatureC,
                TemperatureF = e.TemperatureF,
            };
        }
    }
}

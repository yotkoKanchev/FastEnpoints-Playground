using FastEnpointsDemo.Models;

namespace FastEnpointsDemo.Contracts.Responses
{
    public class WeatherForecastsResponse
    {
        public ICollection<WeatherForecastResponse> Forecasts { get; set; }
    }
}

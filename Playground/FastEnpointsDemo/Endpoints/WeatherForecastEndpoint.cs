using FastEndpoints;
using FastEnpointsDemo.Contracts.Requests;
using FastEnpointsDemo.Contracts.Responses;
using FastEnpointsDemo.Mappers;
using FastEnpointsDemo.Models;

namespace FastEnpointsDemo.Endpoints
{
    public class WeatherForecastEndpoint : Endpoint<WeatherForecastRequest, WeatherForecastsResponse, WeatherForecastMapper>
    {
        private static readonly string[] Summaries = new[] { "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };

        public override void Configure()
        {
            Get("weather/{days}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(WeatherForecastRequest request, CancellationToken ct)
        {
            Logger.LogDebug("Retreiving weather for {Days} days", request.Days);


            var forecasts = Enumerable.Range(1, request.Days).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();

            var response = new WeatherForecastsResponse
            {
                Forecasts = forecasts
                                .Select(Map.FromEntity)
                                .ToList()
            };

            //var response = new WeatherForecastsResponse
            //{
            //    Forecasts = forecasts.Select(f => new WeatherForecastResponse
            //    {
            //        Date = f.Date,
            //        Summary = f.Summary,
            //        TemperatureC = f.TemperatureC,
            //    })
            //    .ToList(),
            //};

            await SendAsync(response, cancellation: ct);
        }
    }
}

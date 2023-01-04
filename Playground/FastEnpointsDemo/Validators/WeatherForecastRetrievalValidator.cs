using FastEndpoints;
using FastEnpointsDemo.Contracts.Requests;
using FluentValidation;

namespace FastEnpointsDemo.Validators
{
    public class WeatherForecastRetrievalValidator : Validator<WeatherForecastRequest>
    {
        public WeatherForecastRetrievalValidator()
        {
            RuleFor(r => r.Days)
                .GreaterThanOrEqualTo(1)
                .WithMessage("Weather Forecast days must be at least 1!")
                .LessThanOrEqualTo(14)
                .WithMessage("Weather Forecast can't be retrieved past 14 days!");
        }
    }
}

using FastEndpoints;

namespace FastEnpointsDemo.Endpoints
{
    public class ExampleEndpoint : EndpointWithoutRequest
    {
        public override void Configure()
        {
            Get("example");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            await SendNoContentAsync(ct);
        }
    }
}
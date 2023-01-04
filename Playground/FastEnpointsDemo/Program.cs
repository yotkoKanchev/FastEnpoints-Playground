using FastEndpoints;
using FastEndpoints.Swagger;

var builder = WebApplication.CreateBuilder();

builder.Services
    .AddFastEndpoints()
    .AddSwaggerDoc();

var app = builder.Build();

app
    .UseAuthorization()
    .UseFastEndpoints()
    .UseSwaggerGen(uiConfig: c => c.Path = "/api-docs");

app.Run();
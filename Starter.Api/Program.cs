using Scalar.AspNetCore;
using Starter.Api.Capabilities.Feature;
using Starter.Api.Capabilities.Pipeline;
using Starter.Api.Features.Greeting;
using Starter.Api.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services
    .AddOpenApi()
    .AddPipelineBehaviors()
    .AddExceptionHandler<ExceptionHandler>()
    .AddFeature<GreetingFeature>();

var app = builder.Build();

app.UseExceptionHandler(_ => { });

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseFeature<GreetingFeature>();
app.UseHttpsRedirection();
app.Run();
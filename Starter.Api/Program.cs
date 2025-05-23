using Scalar.AspNetCore;
using Starter.Api.Extensions.Command;
using Starter.Api.Extensions.Endpoint;
using Starter.Api.Extensions.Query;
using Starter.Api.Extensions.Validator;
using Starter.Api.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services
    .AddOpenApi()
    .AddValidators()
    .AddCommand()
    .AddQuery()
    .AddEndpoints()
    .AddExceptionHandler<ExceptionHandler>();


var app = builder.Build();

app.UseExceptionHandler(_ => { });

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.MapEndpoints();
app.UseHttpsRedirection();
app.Run();
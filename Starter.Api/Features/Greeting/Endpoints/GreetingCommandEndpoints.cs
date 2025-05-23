using Microsoft.AspNetCore.Mvc;
using Starter.Api.Extensions;
using Starter.Api.Extensions.Command;
using Starter.Api.Extensions.Endpoint;
using Starter.Api.Features.Greeting.Commands.Generate;

namespace Starter.Api.Features.Greeting.Endpoints;

internal sealed class GreetingCommandEndpoints : IEndpoint
{
    private sealed record GreetingRequest(string Name);
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/greetings", GenerateGreeting)
            .WithName("Generate")
            .WithTags("Greeting", "Command")
            .Produces<string>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest);
    }
    
    private static async Task<IResult> GenerateGreeting(
        [FromBody] GreetingRequest req,
        [FromServices] ICommand<GenerateGreetingCommand, string> handler)
    {
        var cmd = new GenerateGreetingCommand(req.Name);
        var res = await handler.HandleAsync(cmd);
        return res.ToCreatedIResult(id => "/greetings");
    }
}
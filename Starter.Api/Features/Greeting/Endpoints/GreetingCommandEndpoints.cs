using Microsoft.AspNetCore.Mvc;
using Starter.Api.Capabilities;
using Starter.Api.Capabilities.Command;
using Starter.Api.Capabilities.Endpoint;
using Starter.Api.Features.Greeting.Commands.Generate;
using Starter.Api.Shared.Errors;

namespace Starter.Api.Features.Greeting.Endpoints;

internal sealed class GreetingCommandEndpoints : IEndpoint
{
    private sealed record GreetingRequest(string Name);

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/", async (
                [FromBody] GreetingRequest req,
                [FromServices] ICommandBus bus) =>
            {
                var cmd = new GenerateGreetingCommand(req.Name);
                return (await bus.Dispatch<GenerateGreetingCommand, string>(cmd)).ToIResult();
            })
            .WithName("Greeting.Generate")
            .WithTags("Greeting")
            .Produces<string>(StatusCodes.Status201Created)
            .Produces<Error>(StatusCodes.Status400BadRequest);
    }
}
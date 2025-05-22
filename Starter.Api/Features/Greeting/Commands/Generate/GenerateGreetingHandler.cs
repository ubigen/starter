using Starter.Api.Extensions.Command;
using Starter.Api.Features.Greeting.Domain;
using Starter.Api.Shared.Results;

namespace Starter.Api.Features.Greeting.Commands.Generate;

internal sealed class GenerateGreetingHandler : ICommand<GenerateGreetingCommand, string>
{
    public async Task<Result<string>> HandleAsync(GenerateGreetingCommand cmd)
    {
        var greetingMessage = GreetingMessage.Create(cmd.Name);
        return greetingMessage.ToString();
    }
}
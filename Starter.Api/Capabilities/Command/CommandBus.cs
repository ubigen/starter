using Starter.Api.Capabilities.Pipeline;
using Starter.Api.Shared.Results;

namespace Starter.Api.Capabilities.Command;

public sealed class CommandBus(IServiceProvider sp) : ICommandBus
{
    public Task<Result<TResult>> Dispatch<TCommand, TResult>(TCommand command)
        where TCommand : class
    {
        var handler   = sp.GetRequiredService<ICommand<TCommand, TResult>>();
        
        var behaviors = sp.GetServices<IPipelineBehavior<TCommand, TResult>>().Reverse();

        Func<TCommand, Task<Result<TResult>>> exec = handler.HandleAsync;
        
        foreach (var b in behaviors)
        {
            var next = exec;
            exec = c => b.HandleAsync(c, next);
        }
        return exec(command);
    }
}
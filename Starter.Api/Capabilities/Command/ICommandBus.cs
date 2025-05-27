using Starter.Api.Shared.Results;

namespace Starter.Api.Capabilities.Command;

public interface ICommandBus
{
    Task<Result<TResult>> Dispatch<TCommand, TResult>(TCommand command) where TCommand : class;
}
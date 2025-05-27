using Starter.Api.Shared.Results;

namespace Starter.Api.Capabilities.Pipeline;

public interface IPipelineBehavior<TCommand, TResult> where TCommand : class
{
    Task<Result<TResult>> HandleAsync(TCommand command, Func<TCommand, Task<Result<TResult>>> next);
}
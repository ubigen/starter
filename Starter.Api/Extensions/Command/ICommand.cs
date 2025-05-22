using Starter.Api.Shared.Results;

namespace Starter.Api.Extensions.Command;

public interface ICommand<in TCommand, TResponse>
{
    Task<Result<TResponse>> HandleAsync(TCommand cmd);
}
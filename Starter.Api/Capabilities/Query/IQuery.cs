using Starter.Api.Shared.Results;

namespace Starter.Api.Capabilities.Query;

public interface IQuery<in TRequest, TResponse>
{
    Task<Result<TResponse>> HandleAsync(TRequest req);
}
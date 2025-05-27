using Starter.Api.Shared.Results;

namespace Starter.Api.Capabilities;

public static class ResultExtension
{
    public static IResult ToCreatedIResult<TValue>(this Result<TValue> result, Func<TValue, string> locationUriFunc)
        => result.IsSuccess
            ? Results.Created(locationUriFunc(result.Value), result.Value)
            : result.Error.ToIResult();
    
    public static IResult ToNoContentIResult(this Result result)
        => result.IsSuccess
            ? Results.NoContent()
            : result.Error.ToIResult();
    public static IResult ToIResult<TValue>(this Result<TValue> result)
        => result.IsSuccess
            ? Results.Ok(result.Value)
            : result.Error.ToIResult();

    public static IResult ToIResult(this Result result)
        => result.IsSuccess
            ? Results.Ok()
            : result.Error.ToIResult();
}
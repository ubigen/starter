using Starter.Api.Shared.Errors;

namespace Starter.Api.Capabilities;

public static class ErrorExtension
{
    public static IResult ToIResult(this Error error) 
        => error.Code switch
        {
            ErrorType.Validation 
                => Results.BadRequest(error),
            
            ErrorType.NotFound 
                => Results.NotFound(error),
            
            ErrorType.Conflict 
                => Results.Conflict(error),
            
            _ => Results.BadRequest(error)
        };
}
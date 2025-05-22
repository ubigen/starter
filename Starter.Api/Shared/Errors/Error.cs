namespace Starter.Api.Shared.Errors;

public record Error(string Type, string Message, ErrorType Code, object Source)
{
    public static readonly Error None = new(String.Empty, string.Empty, ErrorType.Problem, null);
    public static readonly Error NullValue = new(
        ErrorType.Problem.ToString(),
        "Null value was provided",
        ErrorType.Problem,
        null);

    public static Error NotFound(string message, object source)
        => new(ErrorType.NotFound.ToString(), message, ErrorType.NotFound, source);

    public static Error Problem(string message, object source) 
        => new(ErrorType.Problem.ToString(), message, ErrorType.Problem, source);

    public static Error Conflict(string message, object source) 
        => new(ErrorType.Conflict.ToString(), message, ErrorType.Conflict, source);
    
    public static Error Forbidden(string message, object source) 
        => new(ErrorType.Forbidden.ToString(), message, ErrorType.Forbidden, source);
    
    public static Error Validation(object source) 
        => new(ErrorType.Validation.ToString(), "One or more validation failures have occurred.", ErrorType.Validation, source);
}
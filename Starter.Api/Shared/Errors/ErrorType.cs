
namespace Starter.Api.Shared.Errors;

public enum ErrorType
{
    Validation = 400,
    Unauthorized = 401,
    Forbidden = 403,
    NotFound = 404,
    Conflict = 409,
    TooManyRequests = 429,
    Problem = 500,
    NotImplemented = 501,
    BadGateway = 502,
}
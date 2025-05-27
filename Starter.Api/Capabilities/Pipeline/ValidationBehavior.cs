using Starter.Api.Capabilities.Validator;
using Starter.Api.Shared.Errors;
using Starter.Api.Shared.Results;
using Starter.Api.Shared.Validation;

namespace Starter.Api.Capabilities.Pipeline;

public sealed class ValidationBehavior<TCommand, TResult>(IEnumerable<IValidator<TCommand>> validators)
    : IPipelineBehavior<TCommand, TResult>
    where TCommand : class
{
    public async Task<Result<TResult>> HandleAsync(
        TCommand command,
        Func<TCommand, Task<Result<TResult>>> next)
    {
        var result = new ValidationResult();

        foreach (var validator in validators)
            result.Merge(validator.Validate(command));

        if (!result.IsValid)
        {
            var errorDictionary = result.Errors.ToDictionary(
                x => x.Property,
                x => x.Messages.AsEnumerable()
            );

            var error = Error.Validation(errorDictionary);
            return Result.Failure<TResult>(error);
        }

        return await next(command);
    }
}
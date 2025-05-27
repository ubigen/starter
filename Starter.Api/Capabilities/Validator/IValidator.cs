using Starter.Api.Shared.Validation;

namespace Starter.Api.Capabilities.Validator;

public interface IValidator<in T> where T : class
{
    ValidationResult Validate(T cmd);
}